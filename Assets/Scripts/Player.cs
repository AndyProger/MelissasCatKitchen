using System;
using GameEventArgs;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float PlayerRadius = 0.7f;
    private const float PlayerHeight = 2f;
    private const float InteractDistance = 2f;
    
    public static Player Instance { get; private set; }

    public event EventHandler OnWalking;
    public event EventHandler OnStopWalking;
    public event EventHandler<OnSelectedCounterEventArgs> OnSelectedCounterChanged;
    
    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _rotateSpeed = 12f;
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private LayerMask _countersLayerMask;

    private Vector3 _currentDirection;
    private Vector3 _lastDirection;
    private ClearCounter _selectedCounter;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("There are more then one Player instance!");
            
        Instance = this;
    }

    private void Start()
    {
        _gameInput.OnInteractAction += OnInteractAction;
    }

    private void Update()
    {
        HandleInteract();
        MovePlayerIfNeed();
        InvokeEvents();
    }

    private void OnInteractAction(object obj, EventArgs args)
    {
        if (_selectedCounter != null)
            _selectedCounter.Interact();
    }
    
    private void HandleInteract()
    {
        var inputVector = _gameInput.GetMovementNormalizedVector();
        _currentDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        if (_currentDirection != Vector3.zero)
            _lastDirection = _currentDirection;

        if (Physics.Raycast(transform.position, _lastDirection, out var raycastHit, InteractDistance, _countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                if (clearCounter != _selectedCounter)
                    SetSelectedCounter(clearCounter);
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }

    private void SetSelectedCounter(ClearCounter selectedCounter)
    {
        _selectedCounter = selectedCounter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterEventArgs(_selectedCounter));
    }
    
    private void MovePlayerIfNeed()
    {
        var inputVector = _gameInput.GetMovementNormalizedVector();
        _currentDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        var canMove = CanMovePlayer(_currentDirection);

        if (!canMove)
        {
            var moveDirectionX = new Vector3(_currentDirection.x, 0, 0).normalized;
            canMove = CanMovePlayer(moveDirectionX);
            if (canMove)
            {
                _currentDirection = moveDirectionX;
            }
            else
            {
                var moveDirectionZ = new Vector3(0, 0, _currentDirection.z).normalized;
                canMove = CanMovePlayer(moveDirectionZ);

                if (canMove)
                    _currentDirection = moveDirectionZ;
            }
        }

        if (canMove)
            MovePlayer();
    }
    
    private bool CanMovePlayer(Vector3 moveDirection)
    {
        var moveDistance = _moveSpeed * Time.deltaTime;
        var point1 = transform.position;
        var point2 = transform.position + Vector3.up * PlayerHeight;
        return !Physics.CapsuleCast(point1, point2, PlayerRadius, moveDirection, moveDistance);
    }

    private void MovePlayer()
    {
        transform.position += _currentDirection * (_moveSpeed * Time.deltaTime);
        transform.forward = Vector3.Slerp(transform.forward, _currentDirection, Time.deltaTime * _rotateSpeed);
    }

    private void InvokeEvents()
    {
        if (_currentDirection != Vector3.zero)
            OnWalking?.Invoke(this, EventArgs.Empty);
        else
            OnStopWalking?.Invoke(this, EventArgs.Empty);
    }
}

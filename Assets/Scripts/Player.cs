using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const float PLAYER_RADIUS = 0.7f;
    private const float PLAYER_HEIGHT = 2f;
    
    public event Action OnWalking;
    public event Action OnStopWalking;
    
    [SerializeField] private float _moveSpeed = 7f;
    [SerializeField] private float _rotateSpeed = 12f;
    [SerializeField] private GameInput _gameInput;

    private Vector3 _currentDirection;

    private void Update()
    {
        var inputVector = _gameInput.GetMovementNormalizedVector();
        _currentDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        
        MovePlayerIfNeed();
        InvokeEvents();
    }
    
    private bool CanMovePlayer(Vector3 moveDirection)
    {
        var moveDistance = _moveSpeed * Time.deltaTime;
        var point1 = transform.position;
        var point2 = transform.position + Vector3.up * PLAYER_HEIGHT;
        return !Physics.CapsuleCast(point1, point2, PLAYER_RADIUS, moveDirection, moveDistance);
    }

    private void MovePlayerIfNeed()
    {
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

    private void MovePlayer()
    {
        transform.position += _currentDirection * (_moveSpeed * Time.deltaTime);
        transform.forward = Vector3.Slerp(transform.forward, _currentDirection, Time.deltaTime * _rotateSpeed);
    }

    private void InvokeEvents()
    {
        if (_currentDirection != Vector3.zero)
            OnWalking?.Invoke();
        else
            OnStopWalking?.Invoke();
    }
}

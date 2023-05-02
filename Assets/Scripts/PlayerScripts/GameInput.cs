using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;
    
    private PlayerInputActions _playerInputActions;
    
    private void Awake()
    {
        Instance = this;
        
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Interact.performed += OnInteractPerformed;
        _playerInputActions.Player.InteractAlternate.performed += OnInteractAlternatePerformed;
        _playerInputActions.Player.Pause.performed += OnPausePerformed;
    }

    private void OnDestroy()
    {
        _playerInputActions.Player.Interact.performed -= OnInteractPerformed;
        _playerInputActions.Player.InteractAlternate.performed -= OnInteractAlternatePerformed;
        _playerInputActions.Player.Pause.performed -= OnPausePerformed;
        
        _playerInputActions.Dispose();
    }

    private void OnInteractAlternatePerformed(InputAction.CallbackContext obj) => 
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);

    private void OnInteractPerformed(InputAction.CallbackContext obj) => 
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    
    private void OnPausePerformed(InputAction.CallbackContext obj) => 
        OnPauseAction?.Invoke(this, EventArgs.Empty);

    public Vector2 GetMovementNormalizedVector() => 
        _playerInputActions.Player.Move.ReadValue<Vector2>();
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    
    private PlayerInputActions _playerInputActions;
    
    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Interact.performed += OnInteractPerformed;
        _playerInputActions.Player.InteractAlternate.performed += OnInteractAlternatePerformed;
    }
    
    private void OnInteractAlternatePerformed(InputAction.CallbackContext obj) => 
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);

    private void OnInteractPerformed(InputAction.CallbackContext obj) => 
        OnInteractAction?.Invoke(this, EventArgs.Empty);

    public Vector2 GetMovementNormalizedVector() => 
        _playerInputActions.Player.Move.ReadValue<Vector2>();
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    
    private PlayerInputActions _playerInputActions;
    
    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Interact.performed += OnInteractPerformed;
    }

    private void OnInteractPerformed(InputAction.CallbackContext obj) => 
        OnInteractAction?.Invoke(this, EventArgs.Empty);

    public Vector2 GetMovementNormalizedVector() => 
        _playerInputActions.Player.Move.ReadValue<Vector2>();
}

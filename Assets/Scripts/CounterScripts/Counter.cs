using System;
using GameEventArgs;
using UnityEngine;

public abstract class Counter : MonoBehaviour, IKitchenObjectParent
{
    public static event EventHandler OnAnyObjectPlaced;
    
    [SerializeField] protected KitchenObjectSO _kitchenObjectSO;
    [SerializeField] private Transform _counterTopPoint;
    
    public event EventHandler<CounterInteractionArgs> OnCounterInteraction;
    
    public Transform CounterTopPoint => _counterTopPoint;

    public KitchenObject CurrentKitchenObject
    {
        get => _currentKitchenObject;
        set
        {
            _currentKitchenObject = value;
            if (_currentKitchenObject != null)
                OnAnyObjectPlaced?.Invoke(this, EventArgs.Empty);
        }
    }

    private KitchenObject _currentKitchenObject; 

    public virtual void Interact(Player player) { }

    protected void OnCounterInteractionEvent(InteractionType type) => 
        OnCounterInteraction?.Invoke(this, new CounterInteractionArgs(type));
    
    public virtual void InteractAlternate(Player player) { }
    
    public void ClearKitchenObject() => 
        CurrentKitchenObject = null;

    public bool HasKitchenObject() => 
        CurrentKitchenObject != null;
}

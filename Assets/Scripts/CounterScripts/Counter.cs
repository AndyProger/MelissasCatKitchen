using System;
using GameEventArgs;
using UnityEngine;

public abstract class Counter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] protected KitchenObjectScriptableObject _kitchenObjectSO;
    [SerializeField] private Transform _counterTopPoint;
    
    public event EventHandler OnCounterInteraction;
    
    public Transform CounterTopPoint => _counterTopPoint;
    public KitchenObject CurrentKitchenObject { get; set; }

    public virtual void Interact(Player player)
    {
        OnCounterInteraction?.Invoke(this, EventArgs.Empty);
    }
    
    public void ClearKitchenObject() => 
        CurrentKitchenObject = null;

    public bool HasKitchenObject() => 
        CurrentKitchenObject != null;
}

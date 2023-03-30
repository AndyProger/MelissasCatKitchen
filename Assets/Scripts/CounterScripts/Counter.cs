using UnityEngine;

public abstract class Counter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] protected KitchenObjectScriptableObject _kitchenObjectSO;
    [SerializeField] private Transform _counterTopPoint;
    
    public Transform CounterTopPoint => _counterTopPoint;
    public KitchenObject KitchenObject { get; set; }
    
    public abstract void Interact(Player player);
    
    public void ClearKitchenObject() => 
        KitchenObject = null;

    public bool HasKitchenObject() => 
        KitchenObject != null;
}

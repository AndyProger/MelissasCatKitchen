using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectScriptableObject _kitchenObjectSO;

    private IKitchenObjectParent _parent;
    
    public KitchenObjectScriptableObject KitchenObjectSO => _kitchenObjectSO;

    public void SetKitchenObjectParent(IKitchenObjectParent parent)
    {
        if (_parent != null)
            _parent.ClearKitchenObject();
        
        _parent = parent;
        if (parent.HasKitchenObject())
            Debug.LogError("Counter already has a kKitchenObject!");
        
        parent.CurrentKitchenObject = this;
        NormalizePosition(parent);
    }

    public IKitchenObjectParent GetParent() => 
        _parent;

    private void NormalizePosition(IKitchenObjectParent clearCounter)
    {
        transform.parent = clearCounter.CounterTopPoint;
        transform.localPosition = Vector3.zero;
    }
}

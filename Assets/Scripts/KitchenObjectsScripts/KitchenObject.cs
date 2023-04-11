using Unity.VisualScripting;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;

    private IKitchenObjectParent _parent;
    
    public KitchenObjectSO KitchenObjectSO => _kitchenObjectSO;

    public void SetKitchenObjectParent(IKitchenObjectParent parent)
    {
        if (_parent != null)
            _parent.ClearKitchenObject();
        
        _parent = parent;
        if (parent.HasKitchenObject())
            Debug.LogError("Counter already has a KitchenObject!");
        
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

    public void DestroySelf()
    {
        Destroy(gameObject);
        _parent.ClearKitchenObject();
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjectSO obj, IKitchenObjectParent parent)
    {
        var kitchenObjectTransform = Instantiate(obj.Prefab);
        var  kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        kitchenObject.SetKitchenObjectParent(parent);
        return kitchenObject;
    }
}

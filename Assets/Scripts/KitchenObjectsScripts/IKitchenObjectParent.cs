using UnityEngine;

public interface IKitchenObjectParent
{
    Transform CounterTopPoint { get; } // TODO: Rename
    KitchenObject KitchenObject { get; set; }
    void ClearKitchenObject();
    bool HasKitchenObject();
}

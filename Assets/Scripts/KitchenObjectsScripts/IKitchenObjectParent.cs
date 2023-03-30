using UnityEngine;

public interface IKitchenObjectParent
{
    Transform CounterTopPoint { get; } // TODO: Rename
    KitchenObject CurrentKitchenObject { get; set; }
    void ClearKitchenObject();
    bool HasKitchenObject();
}

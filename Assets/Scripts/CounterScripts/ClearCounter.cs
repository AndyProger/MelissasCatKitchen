public class ClearCounter : Counter, IKitchenObjectParent
{
    public override void Interact(Player player)
    {
        if (!HasKitchenObject() && player.HasKitchenObject())
        {
            player.CurrentKitchenObject.SetKitchenObjectParent(this);
            return;
        }
        
        if (HasKitchenObject() && !player.HasKitchenObject())
            CurrentKitchenObject.SetKitchenObjectParent(player);
    }
}

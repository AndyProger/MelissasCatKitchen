public class ClearCounter : Counter, IKitchenObjectParent
{
    public override void Interact(Player player)
    {
        if (!HasKitchenObject() && player.HasKitchenObject())
        {
            player.CurrentKitchenObject.SetKitchenObjectParent(this);
            return;
        }

        if (!HasKitchenObject()) 
            return;
        
        if (player.HasKitchenObject())
        {
            if (player.CurrentKitchenObject.TryGetPlate(out var plateKitchenObject))
            {
                if (plateKitchenObject.TryAddIngredient(CurrentKitchenObject.KitchenObjectSO))
                    CurrentKitchenObject.DestroySelf();
            }
            else
            {
                if (CurrentKitchenObject.TryGetPlate(out plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(player.CurrentKitchenObject.KitchenObjectSO))
                        player.CurrentKitchenObject.DestroySelf();
                }
            }
            
            return;
        }
            
        CurrentKitchenObject.SetKitchenObjectParent(player);
    }
}

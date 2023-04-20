public class DeliveryCounter : Counter
{
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject()) 
            return;
        
        if (player.CurrentKitchenObject.TryGetPlate(out var plateKitchenObject))
            player.CurrentKitchenObject.DestroySelf();
    }
}

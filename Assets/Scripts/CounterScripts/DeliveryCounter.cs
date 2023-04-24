using System;

public class DeliveryCounter : Counter
{
    public static  DeliveryCounter Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject()) 
            return;
        
        if (player.CurrentKitchenObject.TryGetPlate(out var plateKitchenObject))
        {
            DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);
            player.CurrentKitchenObject.DestroySelf();
        }
    }
}

using GameEventArgs;

public class ContainerCounter : Counter
{
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
            return;
        
        KitchenObject.SpawnKitchenObject(_kitchenObjectSO, player);
        OnCounterInteractionEvent(InteractionType.GetFromContainer);
    }
}

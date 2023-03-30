public class ContainerCounter : Counter
{
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
            return;
        
        var kitchenObjectTransform = Instantiate(_kitchenObjectSO.Prefab);
        kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
        base.Interact(player);
    }
}

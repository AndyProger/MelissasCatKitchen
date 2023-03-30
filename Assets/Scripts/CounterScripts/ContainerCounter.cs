public class ContainerCounter : Counter
{
    public override void Interact(Player player)
    {
        var kitchenObjectTransform = Instantiate(_kitchenObjectSO.Prefab);
        kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
    }
}

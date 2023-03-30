using System.Linq;
using UnityEngine;

public class CuttingCounter : Counter
{
    [SerializeField] private CuttingRecipeSO[] _recipes;
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject() 
            && player.HasKitchenObject() 
            && HasRecipesForKitchenObject(player.CurrentKitchenObject))
        {
            player.CurrentKitchenObject.SetKitchenObjectParent(this);
            return;
        }
        
        if (HasKitchenObject() && !player.HasKitchenObject())
            CurrentKitchenObject.SetKitchenObjectParent(player);
    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject())
        {
            var slicedObject = GetSlicedKitchenObject();
            if (slicedObject is null)
                return;
            
            CurrentKitchenObject.DestroySelf();
            ClearKitchenObject();
            KitchenObject.SpawnKitchenObject(slicedObject, this);
        }
    }
    
    private bool HasRecipesForKitchenObject(KitchenObject CurrentKitchenObject) => 
        _recipes.Any(x => x.Before == CurrentKitchenObject.KitchenObjectSO);

    private KitchenObjectSO GetSlicedKitchenObject() => 
        _recipes.FirstOrDefault(x => x.Before == CurrentKitchenObject.KitchenObjectSO)?.After;
}

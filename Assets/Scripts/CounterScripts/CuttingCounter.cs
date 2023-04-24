using System;
using System.Linq;
using GameEventArgs;
using UnityEngine;

public class CuttingCounter : Counter, IHasProgress
{
    public static event EventHandler OnAnyCut;
    
    [SerializeField] private CuttingRecipeSO[] _recipes;

    private int _cuttingProgress;

    public event EventHandler<ProgressEventArgs> OnProgress;
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject() 
            && player.HasKitchenObject() 
            && HasRecipesForKitchenObject(player.CurrentKitchenObject))
        {
            player.CurrentKitchenObject.SetKitchenObjectParent(this);
            _cuttingProgress = 0;
            OnCounterInteractionEvent(InteractionType.Set);
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
                
            return;
        }
            
        CurrentKitchenObject.SetKitchenObjectParent(player);
        OnCounterInteractionEvent(InteractionType.Get);
    }

    public override void InteractAlternate(Player player)
    {
        if (HasKitchenObject())
        {
            var slicedObject = GetSlicedKitchenObject();
            if (slicedObject is null)
                return;

            _cuttingProgress++;
            
            var countNeed = GetCuttingCountNeed();
            OnProgress?.Invoke(this, new ProgressEventArgs(_cuttingProgress, countNeed));
            OnAnyCut?.Invoke(this, EventArgs.Empty);
            if (_cuttingProgress != countNeed)
                return;
            
            CurrentKitchenObject.DestroySelf();
            ClearKitchenObject();
            KitchenObject.SpawnKitchenObject(slicedObject, this);
        }
    }
    
    private bool HasRecipesForKitchenObject(KitchenObject currentKitchenObject) => 
        _recipes.Any(x => x.Before == currentKitchenObject.KitchenObjectSO);

    private KitchenObjectSO GetSlicedKitchenObject() => 
        _recipes.FirstOrDefault(x => x.Before == CurrentKitchenObject.KitchenObjectSO)?.After;
    
    private int GetCuttingCountNeed() => 
        _recipes.First(x => x.Before == CurrentKitchenObject.KitchenObjectSO).CuttingCountNeed;
}

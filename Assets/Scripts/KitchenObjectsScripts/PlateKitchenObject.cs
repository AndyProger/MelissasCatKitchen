using System;
using System.Collections.Generic;
using GameEventArgs;
using UnityEngine;
using UnityEngine.Serialization;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    
    [SerializeField] private List<KitchenObjectSO> _validKitchenObjectsSo;

    public List<KitchenObjectSO> KitchenObjects { get; } = new();

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSo)
    {
        if (!IsValid(kitchenObjectSo))
            return false;
        
        if (KitchenObjects.Contains(kitchenObjectSo))
            return false;
        
        KitchenObjects.Add(kitchenObjectSo);
        OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs(kitchenObjectSo));
        return true;
    }

    private bool IsValid(KitchenObjectSO kitchenObjectSo) => 
        _validKitchenObjectsSo.Contains(kitchenObjectSo);
}

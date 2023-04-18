using System;
using System.Collections.Generic;
using GameEventArgs;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    
    [SerializeField] private List<KitchenObjectSO> _validKitchenObjectsSo;

    private List<KitchenObjectSO> _kitchenObjects = new();

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSo)
    {
        if (!IsValid(kitchenObjectSo))
            return false;
        
        if (_kitchenObjects.Contains(kitchenObjectSo))
            return false;
        
        _kitchenObjects.Add(kitchenObjectSo);
        OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs(kitchenObjectSo));
        return true;
    }

    private bool IsValid(KitchenObjectSO kitchenObjectSo) => 
        _validKitchenObjectsSo.Contains(kitchenObjectSo);
}

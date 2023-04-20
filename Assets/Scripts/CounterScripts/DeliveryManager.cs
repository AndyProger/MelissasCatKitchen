using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// TODO: Migrate on jobs system
public class DeliveryManager : MonoBehaviour
{
    private const float SpawnRecipeTimerMax = 4.0f;
    private const int WaitingRecipesMax = 4;
    
    [SerializeField] private RecipeListSO _recipeListSo;
    
    public static DeliveryManager Instance { get; private set; }
    
    private List<RecipeSO> _waitingRecipesSo = new();
    private float _spawnRecipeTimer;

    private void Awake() => 
        Instance = this;

    private void Update()
    {
        _spawnRecipeTimer -= Time.deltaTime;
        if (_spawnRecipeTimer <= 0f)
        {
            _spawnRecipeTimer = SpawnRecipeTimerMax;
            if (WaitingRecipesMax == _waitingRecipesSo.Count)
                return;
            
            // TODO: Extension method
            var waitingRecipeSO = _recipeListSo.RecipesSo[Random.Range(0, _recipeListSo.RecipesSo.Count)];
            Debug.Log(waitingRecipeSO.RecipeName);
            _waitingRecipesSo.Add(waitingRecipeSO);
        }
    }

    
    // TODO: Refactor this method
    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    {
        foreach (var waitingRecipeSo in _waitingRecipesSo)
        {
            if (waitingRecipeSo.KitchenObjectsSo.Count != plateKitchenObject.KitchenObjects.Count)
                continue;

            var plateContentMatch = true;
            foreach (var recipeKitchenObjectSo in waitingRecipeSo.KitchenObjectsSo)
            {
                var ingredientFound = false;
                foreach (var plateKitchenObjectSo in plateKitchenObject.KitchenObjects)
                {
                    if (plateKitchenObjectSo == recipeKitchenObjectSo)
                    {
                        ingredientFound = true;
                        break;
                    }
                }

                if (!ingredientFound)
                    plateContentMatch = false;
            }
            
            if (plateContentMatch)
            {
                Debug.Log("Match!");
                _waitingRecipesSo.Remove(waitingRecipeSo);
                return;
            }
        }
        
        Debug.Log("Miss!");
    }
}

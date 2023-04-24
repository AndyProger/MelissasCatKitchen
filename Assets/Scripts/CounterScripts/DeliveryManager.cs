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

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public event EventHandler OnRecipeSuccess;
    public event EventHandler OnRecipeFail;
    
    public List<RecipeSO> WaitingRecipesSo { get; } = new();
    private float _spawnRecipeTimer;

    private void Awake() => 
        Instance = this;

    private void Update()
    {
        _spawnRecipeTimer -= Time.deltaTime;
        if (_spawnRecipeTimer <= 0f)
        {
            _spawnRecipeTimer = SpawnRecipeTimerMax;
            if (WaitingRecipesMax == WaitingRecipesSo.Count)
                return;
            
            // TODO: Extension method
            var waitingRecipeSO = _recipeListSo.RecipesSo[Random.Range(0, _recipeListSo.RecipesSo.Count)];
            WaitingRecipesSo.Add(waitingRecipeSO);
            OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
        }
    }

    
    // TODO: Refactor this method
    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    {
        foreach (var waitingRecipeSo in WaitingRecipesSo)
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
                WaitingRecipesSo.Remove(waitingRecipeSo);
                OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                OnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                return;
            }
        }
        
        OnRecipeFail?.Invoke(this, EventArgs.Empty);
    }
}

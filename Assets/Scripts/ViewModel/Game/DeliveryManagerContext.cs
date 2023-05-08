using System;
using System.Collections.Generic;
using System.ComponentModel;
using Model;
using Random = UnityEngine.Random;

namespace ViewModel.Game.Pause
{
    public class DeliveryManagerContext : INotifyPropertyChanged
    {
        public event EventHandler OnRecipeSpawned;
        public event EventHandler OnRecipeCompleted;
        public event EventHandler OnRecipeSuccess;
        public event EventHandler OnRecipeFail;
        public event PropertyChangedEventHandler PropertyChanged;

        public int DeliveredRecipes
        {
            get => _deliveredRecipes;
            private set
            {
                _deliveredRecipes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DeliveredRecipes"));
            }
        }

        private int _deliveredRecipes;
        private float _spawnRecipeTimer;
        
        public void UpdateDeliveryManagerState(float deltaTime, RecipeListSO recipeListSo)
        {
            _spawnRecipeTimer -= deltaTime;
            if (_spawnRecipeTimer <= 0f)
            {
                _spawnRecipeTimer = DeliveryRecipesInfo.SpawnRecipeTimerMax;
                if (DeliveryRecipesInfo.WaitingRecipesMax == Model.Model.DeliveryRecipesInfo.WaitingRecipesSo.Count)
                    return;
            
                // TODO: Extension method
                var waitingRecipeSO = recipeListSo.RecipesSo[Random.Range(0, recipeListSo.RecipesSo.Count)];
                Model.Model.DeliveryRecipesInfo.WaitingRecipesSo.Add(waitingRecipeSO);
                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
        
        // TODO: Refactor this method
        public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
        {
            foreach (var waitingRecipeSo in Model.Model.DeliveryRecipesInfo.WaitingRecipesSo)
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
                    Model.Model.DeliveryRecipesInfo.WaitingRecipesSo.Remove(waitingRecipeSo);
                    DeliveredRecipes++;
                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        
            OnRecipeFail?.Invoke(this, EventArgs.Empty);
        }

        public List<RecipeSO> GetWaitingRecipesSo() => 
            Model.Model.DeliveryRecipesInfo.WaitingRecipesSo;
    }
}
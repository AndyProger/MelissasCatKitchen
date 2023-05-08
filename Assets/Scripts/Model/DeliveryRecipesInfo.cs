using System.Collections.Generic;

namespace Model
{
    public class DeliveryRecipesInfo
    {
        public const float SpawnRecipeTimerMax = 4.0f;
        public const int WaitingRecipesMax = 4;
        
        public List<RecipeSO> WaitingRecipesSo { get; } = new();
    }
}
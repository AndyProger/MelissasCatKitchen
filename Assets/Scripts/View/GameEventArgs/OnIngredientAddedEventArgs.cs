using System;

namespace GameEventArgs
{
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO KitchenObjectSo;

        public OnIngredientAddedEventArgs(KitchenObjectSO kitchenObjectSo) => 
            KitchenObjectSo = kitchenObjectSo;
    }
}
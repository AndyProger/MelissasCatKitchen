using CounterScripts;
using TMPro;
using UnityEngine;
using ViewModel;
using ViewModel.Game.Pause;

public class GameOverView : BaseView
{
    [SerializeField] private TextMeshProUGUI _recipesDeliveredText;

    private int _deliveredRecipes;
    private Binder _deliveredRecipesBinder;
    
    private void Start()
    {
        _deliveredRecipesBinder = new Binder(
            ViewModel.ViewModel.DeliveryManagerContext,
            "DeliveredRecipes",
            _recipesDeliveredText,
            "text");
        
        ViewModel.ViewModel.GameHandlerContext.OnStateChanged += (_, _) =>
        {
            if (ViewModel.ViewModel.GameHandlerContext.CurrentGameState == GameState.GameOver)
                Show();
            else
                Hide();
        };
        
        Hide();
    }
}

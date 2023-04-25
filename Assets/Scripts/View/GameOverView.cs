using CounterScripts;
using TMPro;
using UnityEngine;

public class GameOverView : BaseView
{
    [SerializeField] private TextMeshProUGUI _recipesDeliveredText;

    private int _deliveredRecipes;
    
    private void Start()
    {
        GameHandler.Instance.OnStateChanged += (_, _) =>
        {
            if (GameHandler.Instance.CurrentGameState == GameHandler.GameState.GameOver)
            {
                Show();
                _recipesDeliveredText.text = _deliveredRecipes.ToString();
            }
            else
            {
                Hide();
            }
        };

        DeliveryManager.Instance.OnRecipeSuccess += (_, _) => _deliveredRecipes++;
        Hide();
    }
}

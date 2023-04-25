using CounterScripts;
using TMPro;
using UnityEngine;

public class GameStartCountdownView : BaseView
{
    [SerializeField] private TextMeshProUGUI _countdownText;

    private void Start()
    {
        GameHandler.Instance.OnStateChanged += (_, _) =>
        {
            if (GameHandler.Instance.CurrentGameState == GameHandler.GameState.CountdownToStart)
                Show();
            else
                Hide();
        };
        
        Hide();
    }

    private void Update()
    {
        _countdownText.text = Mathf.Ceil(GameHandler.Instance.CountdownToStartTimer).ToString();
    }
}

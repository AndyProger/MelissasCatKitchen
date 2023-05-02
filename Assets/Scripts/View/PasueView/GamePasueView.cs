using CounterScripts;
using UnityEngine;

public class GamePasueView : BaseView
{
    private void Start()
    {
        GameHandler.Instance.OnGameTogglePause += (_, _) =>
        {
            if (Time.timeScale == 0)
                Show();
            else
                Hide();
        };
        
        Hide();
    }
}

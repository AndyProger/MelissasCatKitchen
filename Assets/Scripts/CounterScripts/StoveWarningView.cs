using CounterScripts;
using UnityEngine;

public class StoveWarningView : BaseView
{
    [SerializeField] private StoveCounter _stoveCounter;

    private void Start()
    {
        _stoveCounter.OnProgress += (_, _) =>
        {
            if (_stoveCounter.CurrentState is StoveCounter.State.Cooked)
                Show();
            else
                Hide();
        };
        
        Hide();
    }
}

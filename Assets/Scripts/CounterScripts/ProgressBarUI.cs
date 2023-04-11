using CounterScripts;
using GameEventArgs;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : BaseUI
{
    [SerializeField] private GameObject _hasProgressGameObject;
    [SerializeField] private Image _barImage;
    
    private IHasProgress _hasProgress;

    private void Start()
    {
        _hasProgress = _hasProgressGameObject.GetComponent<IHasProgress>();
        _hasProgress.OnProgress += OnProgress;
        ResetProgressBar();
        Hide();
    }

    private void OnProgress(object obj, ProgressEventArgs eventArgs)
    {
        _barImage.fillAmount = (float)eventArgs.CuttingProgress / eventArgs.MaxCuttingAttempts;
        if (eventArgs.CuttingProgress == eventArgs.MaxCuttingAttempts)
        {
            Hide();
            ResetProgressBar();
        }
        else
        {
            Show();
        }
    }

    private void ResetProgressBar() => 
        _barImage.fillAmount = 0;
}

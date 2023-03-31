using CounterScripts;
using GameEventArgs;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : BaseUI
{
    [SerializeField] private CuttingCounter _cuttingCounter;
    [SerializeField] private Image _barImage;

    private void Start()
    {
        _cuttingCounter.OnCuttingProgress += OnCuttingProgress;
        _cuttingCounter.OnCounterInteraction += OnCounterInteraction;
        ResetProgressBar();
        Hide();
    }

    private void OnCuttingProgress(object obj, CuttingProgressArgs args) => 
        _barImage.fillAmount = (float) args.CuttingProgress / args.MaxCuttingAttempts;
    
    private void OnCounterInteraction(object obj, CounterInteractionArgs args)
    {
        if (args.InteractionType == InteractionType.Set)
        {
            Show();
        }
        else
        {
            Hide();
            ResetProgressBar();
        }
    }

    private void ResetProgressBar() => 
        _barImage.fillAmount = 0;
}

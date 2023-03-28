using GameEventArgs;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private ClearCounter _clearCounter;
    [SerializeField] private GameObject _selectedEffect;
    
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += OnSelectedCounterChanged;
    }

    private void OnSelectedCounterChanged(object obj, OnSelectedCounterEventArgs args)
    {
        if (args.SelectedCounter == _clearCounter)
            Show();
        else
            Hide();
    }
    
    private void Show() => 
        _selectedEffect.SetActive(true);
    
    private void Hide() => 
        _selectedEffect.SetActive(false);
}

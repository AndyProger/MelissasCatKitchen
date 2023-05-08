using GameEventArgs;
using UnityEngine;
using UnityEngine.Serialization;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private Counter _selectedCounter;
    [SerializeField] private GameObject[] _visualGameObjectsArray;
    
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += OnSelectedCounterChanged;
    }

    private void OnSelectedCounterChanged(object obj, OnSelectedCounterEventArgs args)
    {
        if (args.SelectedCounter == _selectedCounter)
            Show();
        else
            Hide();
    }
    
    private void Show()
    {
        foreach (var visualObject in _visualGameObjectsArray)
            visualObject.SetActive(true);
    }
    
    private void Hide()
    {
        foreach (var visualObject in _visualGameObjectsArray)
            visualObject.SetActive(false);
    }
}

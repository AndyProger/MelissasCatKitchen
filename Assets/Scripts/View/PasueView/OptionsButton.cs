using UnityEngine;
using UnityEngine.UI;

public class OptionsButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private OptionsView _optionsView;

    private void Awake()
    {
        _button.onClick.AddListener(() =>
        {
            _optionsView.Show();
        });
    }
}

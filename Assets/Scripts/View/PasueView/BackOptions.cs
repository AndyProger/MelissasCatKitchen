using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BackOptions : MonoBehaviour
{
    [SerializeField] private Button _button;
    [FormerlySerializedAs("_optinonsView")] [SerializeField] private OptionsView optionsView;

    private void Awake()
    {
        _button.onClick.AddListener(() =>
        {
            optionsView.Hide();
        });
    }
}

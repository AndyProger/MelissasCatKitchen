using UnityEngine;
using View.Meta;

public class OptionsButton : ButtonBase
{
    [SerializeField] private OptionsView _optionsView;

    protected override void OnClick() => _optionsView.Show();
}

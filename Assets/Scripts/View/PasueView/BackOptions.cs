using UnityEngine;
using View.Meta;

public class BackOptions : ButtonBase
{
    [SerializeField] private OptionsView optionsView;

    protected override void OnClick() => optionsView.Hide();
}

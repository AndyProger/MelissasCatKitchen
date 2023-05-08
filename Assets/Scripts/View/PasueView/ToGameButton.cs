using UnityEngine;
using View.Meta;

public class ToGameButton : ButtonBase
{
    [SerializeField] private GameObject _pauseMenu;

    protected override void OnClick()
    {
        _pauseMenu.SetActive(false);
        GameHandler.Instance.TogglePauseGame();
    }
}

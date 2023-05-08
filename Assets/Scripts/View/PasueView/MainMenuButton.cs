using View;
using View.Meta;

public class MainMenuButton : ButtonBase
{
    protected override void OnClick()
    {
        GameHandler.Instance.TogglePauseGame();
        Loader.Load(ViewModel.ViewModel.MainMenuButtonContext.GetSceneToLoad());
    }
}

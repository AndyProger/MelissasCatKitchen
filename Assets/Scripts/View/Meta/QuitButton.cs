namespace View.Meta
{
    public class QuitButton : ButtonBase
    {
        protected override void OnClick() => ViewModel.ViewModel.QuitButtonContext.Quit();
    }
}

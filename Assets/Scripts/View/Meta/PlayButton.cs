namespace View.Meta 
{
    public class PlayButton : ButtonBase
    {
        protected override void OnClick() => 
            Loader.Load(ViewModel.ViewModel.PlayButtonContext.GetSceneToLoad());
    }
}

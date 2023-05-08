using View.Meta;

namespace ViewModel.Game.Pause
{
    public class MainMenuButtonContext
    {
        public Scene GetSceneToLoad()
        {
            // here we choose scene to load
            return Model.Model.MainMenuScene;
        }
    }
}
using View.Meta;

namespace ViewModel
{
    public class PlayButtonContext
    {
        public Scene GetSceneToLoad()
        {
            // here we choose scene to load
            return Model.Model.LevelInfo.CurrentLevel;
        }
    }
}
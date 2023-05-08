using ViewModel.Game.Pause;

namespace ViewModel
{
    public static class ViewModel
    {
        public static readonly PlayButtonContext PlayButtonContext;
        public static readonly QuitButtonContext QuitButtonContext;
        public static readonly MainMenuButtonContext MainMenuButtonContext;

        static ViewModel()
        {
            PlayButtonContext = new();
            QuitButtonContext = new();
            MainMenuButtonContext = new();
        }
    }
}
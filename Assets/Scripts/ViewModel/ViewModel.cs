using ViewModel.Game.Pause;

namespace ViewModel
{
    public static class ViewModel
    {
        public static readonly PlayButtonContext PlayButtonContext;
        public static readonly QuitButtonContext QuitButtonContext;
        public static readonly MainMenuButtonContext MainMenuButtonContext;
        public static readonly GameHandlerContext GameHandlerContext;
        public static readonly DeliveryManagerContext DeliveryManagerContext;

        static ViewModel()
        {
            PlayButtonContext = new();
            QuitButtonContext = new();
            MainMenuButtonContext = new();
            GameHandlerContext = new();
            DeliveryManagerContext = new();
        }
    }
}
using System.Collections.Generic;
using ViewModel.Game.Pause;

namespace ViewModel
{
    public static class ViewModel
    {
        public static PlayButtonContext PlayButtonContext;
        public static QuitButtonContext QuitButtonContext;
        public static MainMenuButtonContext MainMenuButtonContext;
        public static GameHandlerContext GameHandlerContext;
        public static DeliveryManagerContext DeliveryManagerContext;

        public static List<Binder> Binders;

        static ViewModel()
        {
            PlayButtonContext = new();
            QuitButtonContext = new();
            MainMenuButtonContext = new();
            GameHandlerContext = new();
            DeliveryManagerContext = new();

            Binders = new();
        }

        public static void Reset()
        {
            foreach(var binder in Binders)
                binder.Dispose();
            
            PlayButtonContext = new();
            QuitButtonContext = new();
            MainMenuButtonContext = new();
            GameHandlerContext = new();
            DeliveryManagerContext = new();

            Model.Model.Reset();
            Binders.Clear();
        }
    }
}
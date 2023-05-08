using View.Meta;

namespace Model
{
    public static class Model
    {
        public static GameLevelsInfo LevelInfo = new(); // if add new levels deserilize to save progress
        public static Scene MainMenuScene => Scene.MetaScene;
        public static GameStateInfo GameStateInfo;
        public static DeliveryRecipesInfo DeliveryRecipesInfo;

        static Model()
        {
            GameStateInfo = new();
            DeliveryRecipesInfo = new();
        }

        public static void Reset()
        {
            GameStateInfo = new();
            DeliveryRecipesInfo = new();
        }
    }
}
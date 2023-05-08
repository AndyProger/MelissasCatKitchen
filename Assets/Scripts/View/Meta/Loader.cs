using UnityEngine.SceneManagement;

namespace View.Meta
{
    public static class Loader
    {
        private static Scene _targetSceneIndex;

        public static void Load(Scene targetScene)
        {
            _targetSceneIndex = targetScene;
            SceneManager.LoadScene(Scene.LoadingScene.ToString());
        }

        public static void LoaderCallback() => 
            SceneManager.LoadScene(_targetSceneIndex.ToString());
    }
}

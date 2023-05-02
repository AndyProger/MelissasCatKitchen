using UnityEngine.SceneManagement;
using Scene = View.Meta.Scene;

public static class Loader
{
    private static Scene _targetSceneIndex;

    public static void Load(Scene targetScene)
    {
        _targetSceneIndex = targetScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(_targetSceneIndex.ToString());
    }
}

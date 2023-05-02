using UnityEngine;
using UnityEngine.UI;
using View.Meta;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private Button _toMainMenuButton;

    private void Start()
    {
        _toMainMenuButton.onClick.AddListener(() =>
        {
            GameHandler.Instance.TogglePauseGame();
            Loader.Load(Scene.MetaScene);
        });
    }
}

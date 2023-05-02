using UnityEngine;
using UnityEngine.UI;

public class ToGameButton : MonoBehaviour
{
    [SerializeField] private Button _toGameButton;
    [SerializeField] private GameObject _pauseMenu;

    private void Start()
    {
        _toGameButton.onClick.AddListener(() =>
        {
            _pauseMenu.SetActive(false);
            GameHandler.Instance.TogglePauseGame();
        });
    }
}

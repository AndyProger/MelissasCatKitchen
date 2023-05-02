using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    [SerializeField] private Button _quitButton;

    private void Start() => 
        _quitButton.onClick.AddListener(Application.Quit);
}

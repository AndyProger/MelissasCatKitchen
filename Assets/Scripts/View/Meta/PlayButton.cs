using UnityEngine;
using UnityEngine.UI;
using Scene = View.Meta.Scene;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private Button _playButton;

    private void Start() => 
        _playButton.onClick.AddListener(() => Loader.Load(Scene.GameScene));
}

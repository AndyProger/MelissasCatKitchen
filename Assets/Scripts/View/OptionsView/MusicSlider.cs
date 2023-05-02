using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(x =>
        {
            MusicManager.Instance.ChangeVolume(x);
        });

        var saveVolume = PlayerPrefs.GetFloat(MusicManager.PlayerMusicVolumeSavedValue, 1f);
        MusicManager.Instance.ChangeVolume(saveVolume);
        _slider.value = saveVolume;
    }
}

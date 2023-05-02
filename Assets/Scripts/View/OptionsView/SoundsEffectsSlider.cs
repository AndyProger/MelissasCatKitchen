using UnityEngine;
using UnityEngine.UI;

public class SoundsEffectsSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    private void Awake()
    {
        _slider.onValueChanged.AddListener(x =>
        {
            SoundManager.Instance.ChangeVolume(x);
        });

        var savedVolume = PlayerPrefs.GetFloat(SoundManager.PlayerSoundEffectSavedValue, 1f);
        SoundManager.Instance.ChangeVolume(savedVolume);
        _slider.value = savedVolume;
    }
}

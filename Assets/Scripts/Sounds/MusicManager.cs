using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public const string PlayerMusicVolumeSavedValue = "PlayerMusicVolumeSavedValue";
    
    public static MusicManager Instance { get; private set; }

    private AudioSource _audioSource;

    private void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = PlayerPrefs.GetFloat(PlayerMusicVolumeSavedValue, 1f);
    }

    public void ChangeVolume(float value)
    {
        _audioSource.volume = value;
        PlayerPrefs.SetFloat(PlayerMusicVolumeSavedValue, value);
        PlayerPrefs.Save();
    }
}

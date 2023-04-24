using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
    [SerializeField] private StoveCounter _stoveCounter;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _stoveCounter.OnStoveCounterStateChanged += (_, args) =>
        {
            if (args.State is StoveCounter.State.Cooking or StoveCounter.State.Cooked)
                _audioSource.Play();
            else
                _audioSource.Stop();
        };
    }
}

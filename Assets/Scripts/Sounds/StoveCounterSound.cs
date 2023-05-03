using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
    [SerializeField] private StoveCounter _stoveCounter;

    private AudioSource _audioSource;
    private float _warningSoundTimer;
    private bool _needPlayWarningSound;

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
            
            _needPlayWarningSound = _stoveCounter.CurrentState is StoveCounter.State.Cooked;
        };
    }

    private void Update()
    {
        if (!_needPlayWarningSound)
            return;

        _warningSoundTimer -= Time.deltaTime;
        if (_warningSoundTimer <= 0f)
        {
            var warningSoundTimerMax = 0.2f;
            _warningSoundTimer = warningSoundTimerMax;
            SoundManager.Instance.PlayWarningSound(_stoveCounter.transform.position);
        }
    }
}

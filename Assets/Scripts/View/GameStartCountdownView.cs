using CounterScripts;
using TMPro;
using UnityEngine;

public class GameStartCountdownView : BaseView
{
    private static readonly int Popup = Animator.StringToHash("NumberPopup");
    
    [SerializeField] private TextMeshProUGUI _countdownText;

    private Animator _animator;
    private int _previousCountDownNumber;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameHandler.Instance.OnStateChanged += (_, _) =>
        {
            if (GameHandler.Instance.CurrentGameState == GameHandler.GameState.CountdownToStart)
                Show();
            else
                Hide();
        };
        
        Hide();
    }

    private void Update()
    {
        var countDownNumber = Mathf.CeilToInt(GameHandler.Instance.CountdownToStartTimer);
        _countdownText.text = countDownNumber.ToString();
        if (_previousCountDownNumber != countDownNumber)
        {
            _previousCountDownNumber = countDownNumber;
            _animator.SetTrigger(Popup);
            SoundManager.Instance.PlayCountdownSound();
        }
    }
}

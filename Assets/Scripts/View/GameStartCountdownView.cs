using CounterScripts;
using TMPro;
using UnityEngine;
using ViewModel.Game.Pause;

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
        ViewModel.ViewModel.GameHandlerContext.OnStateChanged += (_, _) =>
        {
            if (ViewModel.ViewModel.GameHandlerContext.CurrentGameState == GameState.CountdownToStart)
                Show();
            else
                Hide();
        };
        
        Hide();
    }

    private void Update()
    {
        var countDownNumber = Mathf.CeilToInt(ViewModel.ViewModel.GameHandlerContext.GetCountdownToStartTimer());
        _countdownText.text = countDownNumber.ToString();
        if (_previousCountDownNumber != countDownNumber)
        {
            _previousCountDownNumber = countDownNumber;
            _animator.SetTrigger(Popup);
            SoundManager.Instance.PlayCountdownSound();
        }
    }
}

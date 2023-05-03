using System;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public enum GameState
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }
    
    private const float GamePlayingTimeSecondsMax = 120f;
    
    public static GameHandler Instance { get; private set; }
    public GameState CurrentGameState { get; private set; }
    public float CountdownToStartTimer { get; private set; } = 3f;
    public float GamePlayingTimer { get; private set; }
    public float NormalizedGamePlayTimeSeconds => 1 - GamePlayingTimer / GamePlayingTimeSecondsMax;
    public event EventHandler OnGameTogglePause;

    public event EventHandler OnStateChanged;
    
    private float _waitingToStartTimer = 1f;

    private void Awake()
    {
        Instance = this;
        CurrentGameState = GameState.WaitingToStart;
    }

    private void Start()
    {
        GameInput.Instance.OnPauseAction += (_, _) => { TogglePauseGame(); };
    }

    private void Update()
    {
        switch (CurrentGameState)
        {
            case GameState.WaitingToStart:
                _waitingToStartTimer -= Time.deltaTime;
                if (_waitingToStartTimer < 0f)
                {
                    CurrentGameState = GameState.CountdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                
                break;
            
            case GameState.CountdownToStart:
                CountdownToStartTimer -= Time.deltaTime;
                if (CountdownToStartTimer < 0f)
                {
                    CurrentGameState = GameState.GamePlaying;
                    GamePlayingTimer = GamePlayingTimeSecondsMax;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                
                break;
            
            case GameState.GamePlaying:
                GamePlayingTimer -= Time.deltaTime;
                if (GamePlayingTimer < 0f)
                {
                    CurrentGameState = GameState.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                
                break;
            
            case GameState.GameOver:
                break;
        }
    }

    public bool IsGamePlaying() => 
        CurrentGameState == GameState.GamePlaying;

    public void TogglePauseGame()
    {
        Time.timeScale = Time.timeScale == 0f ? 1 : 0;
        OnGameTogglePause?.Invoke(this, EventArgs.Empty);
    }
}

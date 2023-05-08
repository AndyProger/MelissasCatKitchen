using System;
using System.ComponentModel;
using Model;

namespace ViewModel.Game.Pause
{
    public class GameHandlerContext
    {
        public GameState CurrentGameState { get; private set; }

        public event EventHandler OnStateChanged;

        public GameHandlerContext()
        {
            CurrentGameState = GameState.WaitingToStart;
        }
        
        public void UpdateCurrentGameState(float deltaTime)
        {
            switch (CurrentGameState)
            {
                case GameState.WaitingToStart:
                    ProcessWaitingToStartState(deltaTime);
                    break;
            
                case GameState.CountdownToStart:
                    ProcessCountdownToStartState(deltaTime);
                    break;
            
                case GameState.GamePlaying:
                    ProcessGamePlayingState(deltaTime);
                    break;
            
                case GameState.GameOver:
                    break;
            }
        }

        private void ProcessWaitingToStartState(float deltaTime)
        {
            Model.Model.GameStateInfo.WaitingToStartTimer -= deltaTime;
            if (!(Model.Model.GameStateInfo.WaitingToStartTimer < 0f)) 
                return;
            
            CurrentGameState = GameState.CountdownToStart;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
        
        private void ProcessCountdownToStartState(float deltaTime)
        {
            Model.Model.GameStateInfo.CountdownToStartTimer -= deltaTime;
            if (!(Model.Model.GameStateInfo.CountdownToStartTimer < 0f)) 
                return;
            
            CurrentGameState = GameState.GamePlaying;
            Model.Model.GameStateInfo.GamePlayingTimer = GameStateInfo.GamePlayingTimeSecondsMax;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }

        private void ProcessGamePlayingState(float deltaTime)
        {
            Model.Model.GameStateInfo.GamePlayingTimer -= deltaTime;
            if (!(Model.Model.GameStateInfo.GamePlayingTimer < 0f)) 
                return;
            
            CurrentGameState = GameState.GameOver;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool IsGamePlaying() => 
            CurrentGameState == GameState.GamePlaying;

        public float GetCountdownToStartTimer() => 
            Model.Model.GameStateInfo.CountdownToStartTimer;
        
        public float GetNormalizedGamePlayTimeSeconds() => 
            Model.Model.GameStateInfo.NormalizedGamePlayTimeSeconds;
    }
}
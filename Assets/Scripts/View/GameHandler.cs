using System;
using Unity.Burst;
using UnityEngine;

namespace View
{
    public class GameHandler : MonoBehaviour
    {
        public static GameHandler Instance { get; private set; }
        public event EventHandler OnGameTogglePause;

        private void Awake() => 
            Instance = this;

        private void Start()
        {
            GameInput.Instance.OnPauseAction += (_, _) => { TogglePauseGame(); };
        }

        [BurstCompile]
        private void Update()
        {
            ViewModel.ViewModel.GameHandlerContext.UpdateCurrentGameState(Time.deltaTime);
        }

        public void TogglePauseGame()
        {
            Time.timeScale = Time.timeScale == 0f ? 1 : 0;
            OnGameTogglePause?.Invoke(this, EventArgs.Empty);
        }
    }
}

namespace Model
{
    public class GameStateInfo
    {
        public const float GamePlayingTimeSecondsMax = 120f;
        
        public float WaitingToStartTimer { get; set; } = 1f;
        public float CountdownToStartTimer { get; set; } = 3f;
        public float GamePlayingTimer { get; set; }
        
        public float NormalizedGamePlayTimeSeconds => 1 - GamePlayingTimer / GamePlayingTimeSecondsMax;
    }
}
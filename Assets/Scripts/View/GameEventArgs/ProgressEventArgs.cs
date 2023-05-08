namespace GameEventArgs
{
    public class ProgressEventArgs
    {
        public float CuttingProgress;
        public float MaxCuttingAttempts;

        public ProgressEventArgs(float cuttingProgress, float maxCuttingAttempts)
        {
            CuttingProgress = cuttingProgress;
            MaxCuttingAttempts = maxCuttingAttempts;
        }
    }
}
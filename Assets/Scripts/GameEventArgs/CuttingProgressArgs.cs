namespace GameEventArgs
{
    public class CuttingProgressArgs
    {
        public int CuttingProgress;
        public int MaxCuttingAttempts;

        public CuttingProgressArgs(int cuttingProgress, int maxCuttingAttempts)
        {
            CuttingProgress = cuttingProgress;
            MaxCuttingAttempts = maxCuttingAttempts;
        }
    }
}
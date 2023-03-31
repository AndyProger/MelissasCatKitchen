namespace GameEventArgs
{
    public class CounterInteractionArgs : System.EventArgs
    {
        public InteractionType InteractionType;

        public CounterInteractionArgs(InteractionType type) => 
            InteractionType = type;
    }

    public enum InteractionType
    {
        Unknown = 0,
        Set = 1,
        Get = 2,
        GetFromContainer = 4,
    }
}
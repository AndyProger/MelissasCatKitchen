using System;

namespace GameEventArgs
{
    public class OnCounterInteractionArgs : EventArgs
    {
        public Counter IntereactedCounter;

        public OnCounterInteractionArgs(Counter counter) => 
            IntereactedCounter = counter;
    }
}
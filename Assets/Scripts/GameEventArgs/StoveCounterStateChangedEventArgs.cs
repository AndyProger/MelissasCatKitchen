using System;

namespace GameEventArgs
{
    public class StoveCounterStateChangedEventArgs : EventArgs
    {
        public StoveCounter.State State;

        public StoveCounterStateChangedEventArgs(StoveCounter.State state) => 
            State = state;
    }
}
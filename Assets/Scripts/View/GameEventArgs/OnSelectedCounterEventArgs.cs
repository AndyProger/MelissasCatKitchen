using System;

namespace GameEventArgs
{
    public class OnSelectedCounterEventArgs : EventArgs
    {
        public Counter SelectedCounter;

        public OnSelectedCounterEventArgs(Counter counter) => 
            SelectedCounter = counter;
    }
}
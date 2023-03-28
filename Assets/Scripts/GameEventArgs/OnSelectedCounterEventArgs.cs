using System;

namespace GameEventArgs
{
    public class OnSelectedCounterEventArgs : EventArgs
    {
        public ClearCounter SelectedCounter;

        public OnSelectedCounterEventArgs(ClearCounter counter) => 
            SelectedCounter = counter;
    }
}
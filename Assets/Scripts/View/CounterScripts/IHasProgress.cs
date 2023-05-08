using System;
using GameEventArgs;

public interface IHasProgress
{
    public event EventHandler<ProgressEventArgs> OnProgress;
}

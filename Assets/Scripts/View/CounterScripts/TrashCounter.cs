using System;

public class TrashCounter : Counter
{
    public static event EventHandler OnAnyObjectTrashed;
    
    public static void ResetTrashCounterEvents()
    {
        OnAnyObjectTrashed = null;
    }
    
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            player.CurrentKitchenObject.DestroySelf();
            OnAnyObjectTrashed?.Invoke(this, EventArgs.Empty);
        }
    }
}

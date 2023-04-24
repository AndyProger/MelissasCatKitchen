using System;

public class TrashCounter : Counter
{
    public static event EventHandler OnAnyObjectTrashed;
    
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            player.CurrentKitchenObject.DestroySelf();
            OnAnyObjectTrashed?.Invoke(this, EventArgs.Empty);
        }
    }
}

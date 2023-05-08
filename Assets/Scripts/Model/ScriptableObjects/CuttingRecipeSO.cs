using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecipeSO : ScriptableObject
{
    public KitchenObjectSO Before;
    public int CuttingCountNeed;
    public KitchenObjectSO After;
}

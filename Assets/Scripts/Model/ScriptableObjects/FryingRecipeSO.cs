using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject
{
    public KitchenObjectSO Before;
    public KitchenObjectSO After;
    public float fryingTimeMax;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class OvercookingRecipeSO : ScriptableObject
{
    public KitchenObjectSO Before;
    public KitchenObjectSO After;
    public float overcookingTimeMax;
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectSoToGameObjectMap
    {
        public KitchenObjectSO KitchenObjectSo;
        public GameObject GameObject;
    }
    
    [SerializeField] private PlateKitchenObject _plateKitchenObject;
    [SerializeField] private List<KitchenObjectSoToGameObjectMap> _kitchenObjectStMaps;

    private void Start()
    {
        foreach (var item in _kitchenObjectStMaps)
            item.GameObject.SetActive(false);
        
        _plateKitchenObject.OnIngredientAdded += (_, args) =>
        {
            foreach (var item in _kitchenObjectStMaps)
            {
                if (item.KitchenObjectSo == args.KitchenObjectSo)
                    item.GameObject.SetActive(true);
            }
        };
    }
}

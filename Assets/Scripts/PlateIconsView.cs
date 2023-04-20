using System;
using UnityEngine;

public class PlateIconsView : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject _plateKitchenObject;
    [SerializeField] private Transform _iconTemplate;

    private void Awake()
    {
        _iconTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        _plateKitchenObject.OnIngredientAdded += (sender, args) =>
        {
            foreach (Transform child in transform)
            {
                if (child != _iconTemplate)
                    Destroy(child.gameObject);
            }
            
            foreach (var kitchenObjectSo in _plateKitchenObject.KitchenObjects)
            {
                var iconTransform = Instantiate(_iconTemplate, transform);
                iconTransform.gameObject.SetActive(true);
                iconTransform.GetComponent<PlateIconsSingleView>().SetKitchenObjectSo(kitchenObjectSo);
            }
        };
    }
}

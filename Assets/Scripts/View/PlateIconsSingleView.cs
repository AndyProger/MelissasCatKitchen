using UnityEngine;
using UnityEngine.UI;

public class PlateIconsSingleView : MonoBehaviour
{
    [SerializeField] private Image _image;
    
    public void SetKitchenObjectSo(KitchenObjectSO kitchenObjectSo) => 
        _image.sprite = kitchenObjectSo.Sprite;
}

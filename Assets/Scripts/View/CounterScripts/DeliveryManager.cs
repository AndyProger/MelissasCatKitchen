using Unity.Burst;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private RecipeListSO _recipeListSo;

    [BurstCompile]
    private void Update()
    {
        ViewModel.ViewModel.DeliveryManagerContext.UpdateDeliveryManagerState(Time.deltaTime, _recipeListSo);
    }
}

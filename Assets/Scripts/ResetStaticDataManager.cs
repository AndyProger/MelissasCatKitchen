using UnityEngine;

public class ResetStaticDataManager : MonoBehaviour
{
    private void Awake()
    {
        CuttingCounter.ResetCuttingCounterEvents();
        Counter.ResetEvents();
        TrashCounter.ResetTrashCounterEvents();
    }
}

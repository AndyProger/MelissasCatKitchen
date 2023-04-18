using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    private const float PlateOffsetY = 0.1f;
    
    [SerializeField] private PlateCounter _plateCounter;
    [SerializeField] private Transform _counterTopPoint;
    [SerializeField] private Transform _plateVisualPrefab;

    private List<GameObject> _plates = new();

    private void Start()
    {
        _plateCounter.OnPlateSpawned += (_, _) =>
        {
            var plateVisualTransform = Instantiate(_plateVisualPrefab, _counterTopPoint);
            plateVisualTransform.localPosition = new Vector3(0, _plates.Count * PlateOffsetY, 0);
            _plates.Add(plateVisualTransform.gameObject);
        };

        _plateCounter.OnPlateRemoved += (_, _) =>
        {
            var lastPlate = _plates.Last();
            _plates.Remove(lastPlate);
            Destroy(lastPlate);
        };
    }
}

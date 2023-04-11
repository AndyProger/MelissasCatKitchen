using UnityEngine;

public class StoveCounterAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _stoveOn;
    [SerializeField] private GameObject _particles;
    [SerializeField] private StoveCounter _stoveCounter;

    private void Start()
    {
        _stoveCounter.OnStoveCounterStateChanged += (_, args) =>
        {
            var needToShow = args.State is StoveCounter.State.Cooking or StoveCounter.State.Cooked;
            _stoveOn.SetActive(needToShow);
            _particles.SetActive(needToShow);
        };
    }
}

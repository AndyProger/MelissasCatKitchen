using UnityEngine;
using UnityEngine.UI;

public class ClockView : MonoBehaviour
{
    [SerializeField] private Image _clockImage;

    private void Update()
    {
        _clockImage.fillAmount = GameHandler.Instance.NormalizedGamePlayTimeSeconds;
    }
}

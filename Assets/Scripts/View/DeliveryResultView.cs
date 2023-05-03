using CounterScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultView : BaseView
{
    private static readonly int Popup = Animator.StringToHash("Popup");
    
    private const string SuccessText = "SUCCESS";
    private const string FailedText = "FAILED";
    
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _messageText;
    
    [SerializeField] private Color _successColor;
    [SerializeField] private Color _failColor;
    
    [SerializeField] private Sprite _successSprite;
    [SerializeField] private Sprite _failSprite;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += (_, _) =>
        {
            _backgroundImage.color = _successColor;
            _iconImage.sprite = _successSprite;
            _messageText.text = SuccessText;
            
            Show();
            _animator.SetTrigger(Popup);
        };
        
        DeliveryManager.Instance.OnRecipeFail += (_, _) =>
        {
            _backgroundImage.color = _failColor;
            _iconImage.sprite = _failSprite;
            _messageText.text = FailedText;
            
            Show();
            _animator.SetTrigger(Popup);
        };
        
        Hide();
    }
}

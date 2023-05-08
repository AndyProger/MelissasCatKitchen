using UnityEngine;
using UnityEngine.UI;

namespace View.Meta
{
    public abstract class ButtonBase : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        private void Start() => 
            _button.onClick.AddListener(OnClick);

        protected abstract void OnClick();
    }
}
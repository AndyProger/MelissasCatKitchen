using UnityEngine;

namespace CounterScripts
{
    public class BaseView : MonoBehaviour
    {
        public void Show() => 
            gameObject.SetActive(true);
        
        public void Hide() => 
            gameObject.SetActive(false);
    }
}
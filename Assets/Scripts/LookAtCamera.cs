using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private bool IsInverted;
    
    private void LateUpdate()
    {
        if (IsInverted)
            transform.LookAt(transform.position - Camera.main.transform.position);
        else
            transform.LookAt(Camera.main.transform);

        transform.forward = Camera.main.transform.forward;
    }
}

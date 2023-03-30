using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    [SerializeField] private Animator _animator;

    private bool _isWalking;

    private void Start()
    {
        Player.Instance.OnWalking += (_, _) => SetWalkingMode(true);
        Player.Instance.OnStopWalking += (_, _) => SetWalkingMode(false);
    }

    private void SetWalkingMode(bool isWalking)
    {
        if (_isWalking == isWalking) 
            return;
        
        _isWalking = isWalking;
        _animator.SetBool(IsWalking, isWalking);
    }
}

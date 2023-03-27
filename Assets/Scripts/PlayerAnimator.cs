using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKNIG = "IsWalking";
    
    [SerializeField] private Animator _animator;
    [SerializeField] private Player _player;

    private bool _isWalking;

    private void Start()
    {
        _player.OnWalking += () => SetWalkingMode(true);
        _player.OnStopWalking += () => SetWalkingMode(false);
    }

    private void SetWalkingMode(bool isWalking)
    {
        if (_isWalking == isWalking) 
            return;
        
        _isWalking = isWalking;
        _animator.SetBool(IS_WALKNIG, isWalking);
    }
}

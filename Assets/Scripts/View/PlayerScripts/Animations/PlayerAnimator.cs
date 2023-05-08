using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private static readonly int Running = Animator.StringToHash("Running");
    private static readonly int HoldAndRun = Animator.StringToHash("HoldAndRun");
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int IdleAndHold = Animator.StringToHash("IdleAndHold");

    [SerializeField] private Animator _animator;

    private void Start()
    {
        Player.Instance.OnWalking += (_, _) => SetWalkingMode(true);
        Player.Instance.OnStopWalking += (_, _) => SetWalkingMode(false);
    }

    private void SetWalkingMode(bool isWalking)
    {
        if (Player.Instance.HasKitchenObject())
        {
            _animator.SetTrigger(isWalking ? HoldAndRun : IdleAndHold);
            _animator.ResetTrigger(!isWalking ? HoldAndRun : IdleAndHold);
            return;
        }
        
        _animator.SetTrigger(isWalking ? Running : Idle);
        _animator.ResetTrigger(!isWalking ? Running : Idle);
    }
}

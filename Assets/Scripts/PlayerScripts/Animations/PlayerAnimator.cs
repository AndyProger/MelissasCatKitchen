using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private static readonly int Running = Animator.StringToHash("Running");
    private static readonly int Idle = Animator.StringToHash("Idle");

    [SerializeField] private Animator _animator;

    private void Start()
    {
        Player.Instance.OnWalking += (_, _) => SetWalkingMode(true);
        Player.Instance.OnStopWalking += (_, _) => SetWalkingMode(false);
    }

    private void SetWalkingMode(bool isWalking)
    {
        _animator.SetTrigger(isWalking ? Running : Idle);
        _animator.ResetTrigger(!isWalking ? Running : Idle);
    }
}

using GameEventArgs;
using UnityEngine;

public class ContainerCounterAnimation : MonoBehaviour
{
    private static readonly int OpenClose = Animator.StringToHash("OpenClose");
    
    [SerializeField] private Animator _animator;

    private void Start() => 
        Player.Instance.OnCounterInteraction += OnCounterInteraction;

    private void OnCounterInteraction(object obj, OnCounterInteractionArgs args) => 
        _animator.SetTrigger(OpenClose);
}

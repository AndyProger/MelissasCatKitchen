using System;
using UnityEngine;

public class ContainerCounterAnimation : MonoBehaviour
{
    private static readonly int OpenClose = Animator.StringToHash("OpenClose");
    
    [SerializeField] private Animator _animator;
    [SerializeField] private Counter _animatedCounter;

    private void Start() => 
        _animatedCounter.OnCounterInteraction += OnCounterInteraction;

    private void OnCounterInteraction(object obj, EventArgs args) => 
        _animator.SetTrigger(OpenClose);
}

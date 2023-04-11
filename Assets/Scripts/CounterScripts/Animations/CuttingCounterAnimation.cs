using System;
using GameEventArgs;
using UnityEngine;

public class CuttingCounterAnimation : MonoBehaviour
{
    private static readonly int Cut = Animator.StringToHash("Cut");
    
    [SerializeField] private Animator _animator;
    [SerializeField] private CuttingCounter _animatedCounter;

    private void Start() => 
        _animatedCounter.OnProgress += OnCounterInteraction;

    private void OnCounterInteraction(object obj, ProgressEventArgs eventArgs) => 
        _animator.SetTrigger(Cut);
}

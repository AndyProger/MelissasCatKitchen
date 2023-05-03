using System;
using System.Linq;
using GameEventArgs;
using UnityEngine;
using UnityEngine.Serialization;

public class StoveCounter : Counter, IHasProgress
{
    public enum State // TODO: Move to file
    {
        Idle = 1,
        Cooking = 2,
        Cooked = 3,
        Overcooked = 4,
    }
    
    [SerializeField] private FryingRecipeSO[] _fryingRecipesSo;
    [SerializeField] private OvercookingRecipeSO[] _overcookingRecipesSo;

    public event EventHandler<StoveCounterStateChangedEventArgs> OnStoveCounterStateChanged;
    public event EventHandler<ProgressEventArgs> OnProgress;

    public State CurrentState { get; private set; }
    private float _fryingTimer;
    private float _overcookingTimer;
    private FryingRecipeSO _fryingRecipeSo;
    private OvercookingRecipeSO _overcookingRecipeSo;

    private void Start()
    {
        CurrentState = State.Idle;
    }

    private void Update()
    {
        if (!HasKitchenObject()) 
            return;
        
        switch (CurrentState)
        {
            case State.Idle:
                break;
            case State.Cooking:
                _fryingTimer += Time.deltaTime;
                OnProgress?.Invoke(this, new ProgressEventArgs(_fryingTimer, _fryingRecipeSo.fryingTimeMax));
                
                if (_fryingTimer > _fryingRecipeSo.fryingTimeMax)
                {
                    CurrentKitchenObject.DestroySelf();
                    KitchenObject.SpawnKitchenObject(_fryingRecipeSo.After, this);
                    CurrentState = State.Cooked;
                    _overcookingTimer = 0.0f;
                    _overcookingRecipeSo = GetOvercookingRecipeSo();
                    
                    OnStoveCounterStateChanged?.Invoke(this, new StoveCounterStateChangedEventArgs(CurrentState));
                    OnProgress?.Invoke(this, new ProgressEventArgs((int) _fryingRecipeSo.fryingTimeMax, (int) _fryingRecipeSo.fryingTimeMax));
                }
                break;
            case State.Cooked:
                _overcookingTimer += Time.deltaTime;
                OnProgress?.Invoke(this, new ProgressEventArgs(_overcookingTimer, _overcookingRecipeSo.overcookingTimeMax));
                
                if (_overcookingTimer > _overcookingRecipeSo.overcookingTimeMax)
                {
                    CurrentKitchenObject.DestroySelf();
                    KitchenObject.SpawnKitchenObject(_overcookingRecipeSo.After, this);
                    CurrentState = State.Overcooked;
                    OnStoveCounterStateChanged?.Invoke(this, new StoveCounterStateChangedEventArgs(CurrentState));
                    OnProgress?.Invoke(this, new ProgressEventArgs(_overcookingRecipeSo.overcookingTimeMax, _overcookingRecipeSo.overcookingTimeMax));
                }
                break;
            case State.Overcooked:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject() 
            && player.HasKitchenObject() 
            && HasRecipesForKitchenObject(player.CurrentKitchenObject))
        {
            player.CurrentKitchenObject.SetKitchenObjectParent(this);
            _fryingRecipeSo = GetFryingRecipeSo();
            CurrentState = State.Cooking;
            OnStoveCounterStateChanged?.Invoke(this, new StoveCounterStateChangedEventArgs(CurrentState));
            _fryingTimer = 0.0f;
            return;
        }

        if (!HasKitchenObject()) 
            return;
        
        if (player.HasKitchenObject())
        {
            if (player.CurrentKitchenObject.TryGetPlate(out var plateKitchenObject))
            {
                if (plateKitchenObject.TryAddIngredient(CurrentKitchenObject.KitchenObjectSO))
                {
                    CurrentKitchenObject.DestroySelf();
                    ResetState();
                }
            }
                
            return;   
        }
            
        CurrentKitchenObject.SetKitchenObjectParent(player);
        ResetState();
    }

    private void ResetState()
    {
        CurrentState = State.Idle;
        OnStoveCounterStateChanged?.Invoke(this, new StoveCounterStateChangedEventArgs(CurrentState));
        OnProgress?.Invoke(this, new ProgressEventArgs(0, 0));
    }
    
    private bool HasRecipesForKitchenObject(KitchenObject currentKitchenObject) => 
        _fryingRecipesSo.Any(x => x.Before == currentKitchenObject.KitchenObjectSO);
    
    private FryingRecipeSO GetFryingRecipeSo() => 
        _fryingRecipesSo.FirstOrDefault(x => x.Before == CurrentKitchenObject.KitchenObjectSO);
    
    private OvercookingRecipeSO GetOvercookingRecipeSo() => 
        _overcookingRecipesSo.FirstOrDefault(x => x.Before == CurrentKitchenObject.KitchenObjectSO);
}

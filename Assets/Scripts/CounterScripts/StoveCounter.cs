using System;
using System.Linq;
using GameEventArgs;
using UnityEngine;

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

    private State _state;
    private float _fryingTimer;
    private float _overcookingTimer;
    private FryingRecipeSO _fryingRecipeSo;
    private OvercookingRecipeSO _overcookingRecipeSo;

    private void Start()
    {
        _state = State.Idle;
    }

    private void Update()
    {
        if (!HasKitchenObject()) 
            return;
        
        switch (_state)
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
                    _state = State.Cooked;
                    _overcookingTimer = 0.0f;
                    _overcookingRecipeSo = GetOvercookingRecipeSo();
                    
                    OnStoveCounterStateChanged?.Invoke(this, new StoveCounterStateChangedEventArgs(_state));
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
                    _state = State.Overcooked;
                    OnStoveCounterStateChanged?.Invoke(this, new StoveCounterStateChangedEventArgs(_state));
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
            _state = State.Cooking;
            OnStoveCounterStateChanged?.Invoke(this, new StoveCounterStateChangedEventArgs(_state));
            _fryingTimer = 0.0f;
            return;
        } 
        
        if (HasKitchenObject() && !player.HasKitchenObject())
        {
            CurrentKitchenObject.SetKitchenObjectParent(player);
            _state = State.Idle;
            OnStoveCounterStateChanged?.Invoke(this, new StoveCounterStateChangedEventArgs(_state));
            OnProgress?.Invoke(this, new ProgressEventArgs(0, 0));
        }
    }
    
    private bool HasRecipesForKitchenObject(KitchenObject currentKitchenObject) => 
        _fryingRecipesSo.Any(x => x.Before == currentKitchenObject.KitchenObjectSO);
    
    private FryingRecipeSO GetFryingRecipeSo() => 
        _fryingRecipesSo.FirstOrDefault(x => x.Before == CurrentKitchenObject.KitchenObjectSO);
    
    private OvercookingRecipeSO GetOvercookingRecipeSo() => 
        _overcookingRecipesSo.FirstOrDefault(x => x.Before == CurrentKitchenObject.KitchenObjectSO);
}

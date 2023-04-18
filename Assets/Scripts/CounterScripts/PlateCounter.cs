using System;
using UnityEngine;

public class PlateCounter : Counter
{
    private const float SpawnPlateTimerMax = 4f;
    private const int PlatesSpawnedAmountMax = 4;

    [SerializeField] private KitchenObjectSO _plateKitchenObjectSo;

    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;
    
    private float _spawnPlateTimer;
    private int _platesSpawnedAmount;

    private void Update()
    {
        _spawnPlateTimer += Time.deltaTime;
        if (_spawnPlateTimer > SpawnPlateTimerMax)
        {
            _spawnPlateTimer = 0f;

            if (_platesSpawnedAmount < PlatesSpawnedAmountMax)
            {
                _platesSpawnedAmount++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if (player.HasKitchenObject() || _platesSpawnedAmount <= 0) 
            return;
        
        _platesSpawnedAmount--;
        KitchenObject.SpawnKitchenObject(_plateKitchenObjectSo, player);
        OnPlateRemoved?.Invoke(this, EventArgs.Empty);
    }
}

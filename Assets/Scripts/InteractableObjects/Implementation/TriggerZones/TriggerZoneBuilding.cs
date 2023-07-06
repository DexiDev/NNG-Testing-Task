using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Characters.Implementation;
using Game.Inventory;
using UnityEngine;
using Zenject;

namespace Game.InteractableObjects.Implementation.TriggerZones
{
    public abstract class TriggerZoneBuilding<TBuilding> : TriggerZone where TBuilding : IBuilding
    {
        [SerializeField] private float _timerDuration;
        [SerializeField] protected TBuilding _generatedBuilding;

        private CancellationTokenSource _cancellationTokenSource;
        protected InventoryManager _inventoryManager;

        [Inject]
        private void Construct(InventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
        }

        protected override async void OnPlayerEnter(PlayerController playerController)
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new();

            try
            {
                while (!_cancellationTokenSource.IsCancellationRequested)
                {
                    Execute(playerController);
                    await UniTask.Delay(TimeSpan.FromSeconds(_timerDuration), false, PlayerLoopTiming.Update,
                        _cancellationTokenSource.Token);
                }

            }
            catch (OperationCanceledException) { }
        }

        protected override void OnPlayerExit(PlayerController playerController)
        {
            _cancellationTokenSource?.Cancel();
        }

        protected abstract void Execute(PlayerController playerController);
    }
}
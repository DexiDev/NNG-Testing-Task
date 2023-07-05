using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Characters.Implementation;
using Game.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.InteractableObjects
{
    public abstract class TriggerZone : SerializedMonoBehaviour
    {
        [SerializeField] private float _timerDuration;
        [SerializeField] protected IGeneratedBuilding _generatedBuilding;
        

        private CancellationTokenSource _cancellationTokenSource;

        protected InventoryManager _inventoryManager;

        [Inject]
        private void Construct(InventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out PlayerController playerController))
            {
                WhileExecute(playerController);
            }
        }

        private void OnTriggerExit(Collider collider)
        {
            if (collider.gameObject.TryGetComponent(out PlayerController playerController))
            {
                _cancellationTokenSource?.Cancel();
            }
        }

        private async void WhileExecute(PlayerController playerController)
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

        protected abstract void Execute(PlayerController playerController);
    }
}
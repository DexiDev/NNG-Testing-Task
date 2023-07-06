using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Inventory;
using Sirenix.OdinInspector;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Zenject;

namespace Game.InteractableObjects.Implementation
{
    public class Spawner : SerializedMonoBehaviour, IGeneratedBuilding
    {
        [SerializeField] private float _timerDuration;
        
        [field:SerializeField] public Item ItemIn { get; private set; }
        [field:SerializeField] public Item ItemOut { get; private set;}
        [field:SerializeField] public IItemsContainer ItemsContainer { get; private set;}
        
        private CancellationTokenSource _cancellationTokenSource;

        private DiContainer _diContainer;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        private void OnEnable()
        {
            GenerateItem();
        }

        private void OnDisable()
        {
            _cancellationTokenSource?.Cancel();
        }

        public async void GenerateItem()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new();

            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_timerDuration), false, PlayerLoopTiming.Update, _cancellationTokenSource.Token);
                CreateItem(transform);
            }
        }

        public async void CreateItem(Transform targetTransform)
        {
            var item = _diContainer.InstantiatePrefabForComponent<Item>(ItemOut, targetTransform.position, targetTransform.rotation, null);
            item.SetOwner(this);
            ItemsContainer.MoveItem(item);
        }
        
    }
}
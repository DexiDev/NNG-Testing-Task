using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DefaultNamespace;
using Game.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.InteractableObjects.Buildings
{
    public class Factory : SerializedMonoBehaviour, IGeneratedBuilding
    {
        [SerializeField] private float _timerDuration;
        
        [field:SerializeField] public Item ItemIn { get; }
        [field:SerializeField] public Item ItemOut { get; }
        [field:SerializeField] public IItemsContainer ItemsContainer { get; }
        
        [SerializeField] private IItemsContainer _itemsContainerOut; 
        

        private DiContainer _diContainer;
        private InventoryManager _inventoryManager;
        private CancellationTokenSource _cancellationTokenSource;
        
        [Inject]
        private void Construct(InventoryManager inventoryManager, DiContainer diContainer)
        {
            _diContainer = diContainer;
            _inventoryManager = inventoryManager;
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

            try
            {
                while (true)
                {
                    if (_inventoryManager.TryGetItem(this, ItemIn, out Item item, false))
                    {
                        MoveItem(item);
                        await UniTask.Delay(TimeSpan.FromSeconds(_timerDuration), false, PlayerLoopTiming.Update,
                            _cancellationTokenSource.Token);
                    }
                    else
                    {
                        await UniTask.Yield(PlayerLoopTiming.LastUpdate, _cancellationTokenSource.Token);
                    }
                }

            }
            catch (OperationCanceledException) { }
        }

        public void CreateItem(Transform targetTransform)
        {
            var item = _diContainer.InstantiatePrefabForComponent<Item>(ItemOut, targetTransform.position, targetTransform.rotation, transform);
            
            _inventoryManager.Add(this, item);
            
            _itemsContainerOut.MoveItem(item);
        }

        private async void MoveItem(Item item)
        {
            _inventoryManager.Remove(this, item);
            await ItemsContainer.MoveItem(item);

            var itemContainers = item.transform.parent;
            
            Destroy(item);
            
            CreateItem(itemContainers);
        }
    }
}
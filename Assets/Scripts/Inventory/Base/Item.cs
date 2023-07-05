using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Inventory
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private string _id;
        
        private InventoryManager _inventoryManager;
        
        private IInventoryOwner _currentOwner;
        private CancellationTokenSource _cancellationTokenSource;

        private bool _isActive;

        public bool IsActive => _isActive; 

        public string ID => _id;

        [Inject]
        private void Construct(InventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
        }
        
        private void OnDisable()
        {
            _cancellationTokenSource?.Cancel();
        }

        public void SetOwner(IInventoryOwner targetOwner)
        {
            if(_currentOwner != null) _inventoryManager.Remove(_currentOwner, this);
                
            _currentOwner = targetOwner;
                
            _inventoryManager.Add(targetOwner, this);

            // Move(targetOwner.ItemsContainer);
        }

        public async UniTask Move(IItemsContainer itemsContainer)
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new();

            try
            {
                _isActive = true;
                
                
                while (transform.position != itemsContainer.GetPosition() &&
                       !_cancellationTokenSource.IsCancellationRequested)
                {
                    transform.position = Vector3.MoveTowards(transform.position, itemsContainer.GetPosition(),
                        _speed * Time.deltaTime);
                    await UniTask.Yield(_cancellationTokenSource.Token);
                }
                
                transform.SetParent(itemsContainer.GetTransform());
                
                _isActive = false;
            }
            catch (OperationCanceledException ex)
            {
                throw ex;
            }
        }
    }
}
using System;
using Game.InteractableObjects.Implementation.Buildings;
using Game.Inventory;
using TMPro;
using UnityEngine;
using Zenject;

namespace Inventory.Implementation.UI
{
    public class UIItemInventory : MonoBehaviour
    {
        [SerializeField] private Item _item;
        [SerializeField] private TMP_Text _textField;
        
        private StorageBuilding _storageBuilding;
        private InventoryManager _inventoryManager;
        
        [Inject]
        private void Construct([Inject(Id = "Storage")] StorageBuilding storageBuilding, InventoryManager inventoryManager)
        {
            _storageBuilding = storageBuilding;
            _inventoryManager = inventoryManager;
        }

        private void Start()
        {
            _textField.text = _inventoryManager.GetCountItem(_storageBuilding, _item).ToString();
        }

        private void OnEnable()
        {
            _inventoryManager.OnItemAdded += OnItemChanged;
            _inventoryManager.OnItemRemoved += OnItemChanged;
        }

        private void OnDisable()
        {
            
            _inventoryManager.OnItemAdded += OnItemChanged;
            _inventoryManager.OnItemRemoved += OnItemChanged;
        }

        private void OnItemChanged(IInventoryOwner owner, Item item)
        {
            if (!ReferenceEquals(owner, _storageBuilding) || item.ID != _item.ID) return;

            _textField.text = _inventoryManager.GetCountItem(owner, item).ToString();
        }
    }
}
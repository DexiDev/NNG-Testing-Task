using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Inventory;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace DefaultNamespace
{
    public class ListItemsContainer : SerializedMonoBehaviour, IItemsContainer
    {
        [OdinSerialize] private List<IItemsContainer> _itemsContainers = new();
        
        public List<Item> Items { get; } = new();

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
        
        public Transform GetTransform()
        {
            return transform;
        }

        public Vector3 GetPosition(Item item)
        {
            return transform.position;
        }

        public async UniTask MoveItem(Item item)
        {
            try
            {
                foreach (var itemsContainer in _itemsContainers)
                {
                    await itemsContainer.MoveItem(item);
                }
            }
            catch(OperationCanceledException) {}
        }
    }
}
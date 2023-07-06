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
        
        public void AddItem(Item item)
        {
            // _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            // _items.Remove(item);
        }
        
        public Transform GetTransform()
        {
            return transform;
        }

        public Vector3 GetPosition()
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
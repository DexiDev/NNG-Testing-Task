using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    public class ItemsContainer : SerializedMonoBehaviour, IItemsContainer
    {
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
            await item.Move(this);
        }
    }
}
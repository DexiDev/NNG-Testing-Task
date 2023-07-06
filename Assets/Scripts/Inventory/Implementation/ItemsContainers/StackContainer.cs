using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    public class StackContainer : SerializedMonoBehaviour, IItemsContainer
    {
        [SerializeField] private Vector2Int _size;
        [SerializeField] private Vector3 _offset;

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
            var itemsCount = Items.IndexOf(item);

            int zPoint = (int)Math.Truncate((float)itemsCount / _size.x);
            int xPoint = itemsCount - zPoint * _size.x;

            int yPoint = (int)Math.Truncate((float)zPoint / _size.y);
            zPoint -= yPoint * _size.y;

            var offset = new Vector3(xPoint * _offset.x, yPoint * _offset.y, zPoint * _offset.z);

            return offset + transform.position;
        }

        public async UniTask MoveItem(Item item)
        {
            await item.Move(this);
        }
    }
}
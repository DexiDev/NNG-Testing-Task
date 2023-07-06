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

        private List<Item> _items = new();

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public Vector3 GetPosition()
        {
            var itemsCount = _items.Count - 1;

            int zPoint = (int)Math.Truncate((float)itemsCount / _size.x);
            int xPoint = itemsCount - zPoint * _size.x;

            //Y Offset
            int yPoint = (int)Math.Truncate((float)zPoint / _size.y);
            zPoint -= yPoint * _size.y;

            float x = xPoint * _offset.x;
            float y = yPoint * _offset.y;
            float z = zPoint * _offset.z;

            return new Vector3(x, y, z) + transform.position;
        }

        public async UniTask MoveItem(Item item)
        {
            _items.Add(item);
            await item.Move(this);
        }
    }
}
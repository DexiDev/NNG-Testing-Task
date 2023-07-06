using Cysharp.Threading.Tasks;
using Game.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    public class ItemsContainer : SerializedMonoBehaviour, IItemsContainer
    {
        
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
            await item.Move(this);
        }
    }
}
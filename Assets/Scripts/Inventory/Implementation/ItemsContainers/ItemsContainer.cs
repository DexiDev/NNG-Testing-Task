using Cysharp.Threading.Tasks;
using Game.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    public class ItemsContainer : SerializedMonoBehaviour, IItemsContainer
    {
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
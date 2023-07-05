using Cysharp.Threading.Tasks;
using Game.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    public class StackContainer : SerializedMonoBehaviour, IItemsContainer
    {
        // [SerializeField] private
            
        public Transform GetTransform()
        {
            return transform;
        }

        public Vector3 GetPosition()
        {
            throw new System.NotImplementedException();
        }

        public async UniTask MoveItem(Item item)
        {
           await item.Move(this);
        }
    }
}
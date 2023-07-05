using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Inventory
{
    public interface IItemsContainer
    {
        Transform GetTransform();
        
        Vector3 GetPosition();

        UniTask MoveItem(Item item);
    }
}
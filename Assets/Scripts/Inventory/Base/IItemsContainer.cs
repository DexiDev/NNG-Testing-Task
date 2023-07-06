using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Inventory
{
    public interface IItemsContainer
    {
        public void AddItem(Item item);

        public void RemoveItem(Item item);
        
        Transform GetTransform();
        
        Vector3 GetPosition();

        UniTask MoveItem(Item item);
        
    }
}
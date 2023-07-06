using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Inventory
{
    public interface IItemsContainer
    {
        List<Item> Items { get; } 
        public void AddItem(Item item);

        public void RemoveItem(Item item);
        
        Transform GetTransform();
        
        Vector3 GetPosition(Item item);

        UniTask MoveItem(Item item);
        
    }
}
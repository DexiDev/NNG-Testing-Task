using UnityEngine;

namespace Game.Inventory
{
    public interface IInventoryOwner
    {
        IItemsContainer ItemsContainer { get; }
    }
}
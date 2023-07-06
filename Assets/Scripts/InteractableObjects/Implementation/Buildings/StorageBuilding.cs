using Game.InteractableObjects;
using Game.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.InteractableObjects.Implementation.Buildings
{
    public class StorageBuilding : SerializedMonoBehaviour, IStorageBuilding
    {
        [field: SerializeField] public Item ItemIn { get; }
        
        [field: SerializeField] public IItemsContainer ItemsContainer { get; }
    }
}
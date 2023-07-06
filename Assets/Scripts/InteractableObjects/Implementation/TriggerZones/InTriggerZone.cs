using Game.Characters.Implementation;
using Game.Inventory;
using UnityEngine;

namespace Game.InteractableObjects.Implementation.TriggerZones
{
    public class InTriggerZone : TriggerZoneBuilding<IStorageBuilding>
    {
        [SerializeField] private IItemsContainer _itemsContainer;
        
        protected override void Execute(PlayerController playerController)
        {
            if (_inventoryManager.TryGetItem(playerController, _generatedBuilding.ItemIn, out Item item))
            {
                item.transform.SetParent(null);
                item.SetOwner(_generatedBuilding);
                _itemsContainer.MoveItem(item);
            }
        }
    }
}
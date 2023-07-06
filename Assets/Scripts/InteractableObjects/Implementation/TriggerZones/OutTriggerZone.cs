using Game.Characters.Implementation;
using Game.Inventory;

namespace Game.InteractableObjects.Implementation.TriggerZones
{
    public class OutTriggerZone : TriggerZoneBuilding<IGeneratedBuilding>
    {
        protected override void Execute(PlayerController playerController)
        {
            if (_inventoryManager.TryGetItem(_generatedBuilding, _generatedBuilding.ItemOut, out Item item))
            {
                item.transform.SetParent(null);
                item.SetOwner(playerController);
                playerController.ItemsContainer.MoveItem(item);
            }
        }
    }
}
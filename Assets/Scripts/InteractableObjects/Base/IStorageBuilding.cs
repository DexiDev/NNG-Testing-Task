using Game.Inventory;

namespace Game.InteractableObjects
{
    public interface IStorageBuilding : IBuilding
    {
        Item ItemIn { get; }
    }
}
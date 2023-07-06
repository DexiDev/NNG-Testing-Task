using System.Collections.Generic;
using System.Linq;
using Game.Inventory;

namespace Game.Inventory
{
    public class InventoryManager
    {
        private Dictionary<IInventoryOwner, List<Item>> _items = new();
        
        public void Add(IInventoryOwner owner, Item item)
        {
            if(!_items.ContainsKey(owner)) _items.Add(owner, new List<Item>());
            
            _items[owner].Add(item);
        }

        public void Remove(IInventoryOwner owner, Item item)
        {
            if (TryGetItem(owner, item, out Item resultItem))
            {
                _items[owner].Remove(resultItem);
            }
        }

        public bool ContainsItem(IInventoryOwner owner, Item item)
        {
            return TryGetItem(owner, item, out _);
        }

        public Item GetItem(IInventoryOwner owner, Item targetItem, bool isIgnoreActive = true)
        {
            if (!_items.ContainsKey(owner)) return null;

            return _items[owner].LastOrDefault(item => item.ID == targetItem.ID && (isIgnoreActive || !item.IsActive));
        }

        public bool TryGetItem(IInventoryOwner owner, Item targetItem, out Item outItem, bool isIgnoreActive = true)
        {
            outItem = GetItem(owner, targetItem);
            return outItem != null;
        }

    }
}
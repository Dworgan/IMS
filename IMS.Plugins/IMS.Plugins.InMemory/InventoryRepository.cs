using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
       
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10,Price = 2},
                new Inventory { InventoryId = 2, InventoryName = "Bike Body", Quantity = 10,Price = 15},
                new Inventory { InventoryId = 3, InventoryName = "Bike Wheels", Quantity = 20,Price = 8},
                new Inventory { InventoryId = 4, InventoryName = "Bike Pedels", Quantity = 20,Price = 1},

            };
        }

        public Task AddInventoryAsync(Inventory inventory)
        {
            if(_inventories.Any(x=> x.InventoryName.Equals(inventory.InventoryName,StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }
            if(_inventories.Count != 0)
            {
                var maxId = _inventories.Max(x => x.InventoryId);
                inventory.InventoryId = maxId + 1;
            }
            else
            {
                inventory.InventoryId = 1;
            }
            _inventories.Add(inventory);
            return Task.CompletedTask;

        }

        public Task UpdateInventoryAsync(Inventory inventory)
        {
            if(_inventories.Any(x => x.InventoryId != inventory.InventoryId 
                                && x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
            {
                return Task.CompletedTask;
            }
            var invToUpdate = _inventories.FirstOrDefault(x => x.InventoryId == inventory.InventoryId);
            if(invToUpdate != null)
            {
                invToUpdate.InventoryName = inventory.InventoryName;
                invToUpdate.Quantity = inventory.Quantity;
                invToUpdate.Price = inventory.Price;
            }
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return await Task.FromResult(_inventories);
            return _inventories.Where(x => x.InventoryName.Contains(name,StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
        {
            var inv = _inventories.FirstOrDefault(x => x.InventoryId == inventoryId);
            #pragma warning disable CS8603 // Possible null reference return.
            return await Task.FromResult(inv);
            #pragma warning restore CS8603 // Possible null reference return.
        }

        public  Task RemoveInventoryAsync(int inventoryId)
        {
            var inv = _inventories.FirstOrDefault(x => x.InventoryId == inventoryId);
            if (inv != null)
            {
                _inventories.Remove(inv);
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    }
}

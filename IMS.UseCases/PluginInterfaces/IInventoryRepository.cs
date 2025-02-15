﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryRepository
    {
        Task AddInventoryAsync(Inventory inventory);
        Task UpdateInventoryAsync(Inventory inventory);
        Task<IEnumerable<Inventory>> GetInventoriesByName(string name);
        Task<Inventory> GetInventoryByIdAsync(int inventoryId);
        Task RemoveInventoryAsync(int inventoryId);
    }
}

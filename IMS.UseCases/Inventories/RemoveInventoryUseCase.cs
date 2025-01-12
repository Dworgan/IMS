using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Inventories
{
    public class RemoveInventoryUseCase : IRemoveInventoryUseCase
    {
        private readonly IInventoryRepository _inventoryRepository;

        public RemoveInventoryUseCase(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task ExecuteAsync(int inventoryId)
        {
            await _inventoryRepository.RemoveInventoryAsync(inventoryId);
        }
    }
}

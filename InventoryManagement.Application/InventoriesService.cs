using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Models;

namespace InventoryManagement.Application
{
    public class InventoriesService : IInventoriesService
    {
        public Task ProcessInventoryDataAsync(InventoryModel inventoryModel, ICollection<string> productTags)
        {
            throw new NotImplementedException();
        }
    }
}
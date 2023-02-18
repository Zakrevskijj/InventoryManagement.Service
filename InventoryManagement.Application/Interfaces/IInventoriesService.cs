using InventoryManagement.Application.Models;

namespace InventoryManagement.Application.Interfaces
{
    public interface IInventoriesService
    {
        public Task ProcessInventoryDataAsync(InventoryModel inventoryModel, ICollection<string> productTags);
    }
}

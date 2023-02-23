using InventoryManagement.Application.Models;

namespace InventoryManagement.Application.Interfaces
{
    public interface IInventoriesService
    {
        public Task<InventoryModel> CreateInventoryAsync(InventoryModel inventoryModel, ICollection<string> productTags);
        public Task<ICollection<ProductCountModel>> GetProductsCountPerProductByInventoryExternalIdAsync(string externalInventoryId);
        public Task<ICollection<ProductsCountForDayPerProductModel>> GetProductsCountPerDayPerProductAsync();
        public Task<ICollection<ProductsCountForCompanyModel>> GetProductsCountPerCompanyAsync();
    }
}

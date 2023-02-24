using InventoryManagement.Application.Models;

namespace InventoryManagement.Application.Interfaces
{
    public interface IInventoriesService
    {
        public Task<InventoryModel> CreateInventoryAsync(InventoryModel inventoryModel, ICollection<string> productTags);
        public Task<ICollection<ProductCountModel>> GetProductsCountPerProductByInventoryExternalIdAsync(string externalInventoryId);
        public ICollection<ProductsCountForDayPerProductModel> GetProductsCountPerDayPerProduct();
        public ICollection<ProductsCountForCompanyModel> GetProductsCountPerCompany();
    }
}

using InventoryManagement.Application.Models;

namespace InventoryManagement.Application.Interfaces
{
    public interface IInventoriesService
    {
        public Task<InventoryModel> CreateInventoryAsync(InventoryModel inventoryModel, ICollection<string> productTags);
        public Task<ICollection<ProductCountModel>> GetProductsCountPerProductByInventoryExternalId(string externalInventoryId);
        public Task<ICollection<ProductsCountForDayPerProductModel>> GetProductsCountPerDayPerProduct();
        public Task<ICollection<ProductsCountForCompanyModel>> GetProductsCountPerCompany();
    }
}

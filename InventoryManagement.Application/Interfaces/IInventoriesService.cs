using InventoryManagement.Application.Models;

namespace InventoryManagement.Application.Interfaces
{
    public interface IInventoriesService
    {
        public Task CreateInventoryAsync(InventoryModel inventoryModel, ICollection<string> productTags);
        public Task<ICollection<ProductCountModel>> GetProductsCountPerProductByInventoryExternalId(string externalInventoryId);
        public Task<ICollection<ProductsCountForDayModel>> GetProductsCountPerDayPerProduct();
        public Task<ICollection<ProductsCountForCompany>> GetProductsCountPerCompany();
    }
}

using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Models;

namespace InventoryManagement.Application
{
    public class InventoriesService : IInventoriesService
    {
        public Task<InventoryModel> CreateInventoryAsync(InventoryModel inventoryModel, ICollection<string> productTags)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ProductsCountForCompanyModel>> GetProductsCountPerCompany()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ProductsCountForDayPerProductModel>> GetProductsCountPerDayPerProduct()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ProductCountModel>> GetProductsCountPerProductByInventoryExternalId(string externalInventoryId)
        {
            throw new NotImplementedException();
        }

        public Task ProcessInventoryDataAsync(InventoryModel inventoryModel, ICollection<string> productTags)
        {
            throw new NotImplementedException();
        }
    }
}
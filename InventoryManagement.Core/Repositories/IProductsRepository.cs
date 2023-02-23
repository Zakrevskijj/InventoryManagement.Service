using InventoryManagement.Core.Entities;

namespace InventoryManagement.Core.Repositories
{
    public interface IProductsRepository : IRepository<Product>
    {
        public Task<Product> GetProductByCompanyAndItemReferenceAsync(int companyId, int itemReference);
        public IDictionary<Company, int> GetProductsCountPerCompany();
        public IDictionary<Product, int> GetProductsCountPerProductByInventoryId(int inventoryId);
        public IDictionary<DateTime, IDictionary<Product, int>> GetProductsCountPerDayPerProduct();
    }
}

using InventoryManagement.Core.Entities;

namespace InventoryManagement.Core.Repositories
{
    public interface IProductsRepository : IRepository<Product>
    {
        public Task<Product> GetProductByCompanyAndItemReferenceAsync(int companyId, int itemReference);
        public Task<IDictionary<Company, int>> GetProductsCountPerCompanyAsync();
        public Task<IDictionary<Product, int>> GetProductsCountPerProductByInventoryExternalIdAsync();
        public Task<IDictionary<DateTime, IDictionary<Product, int>>> GetProductsCountPerDayPerProductAsync();
    }
}

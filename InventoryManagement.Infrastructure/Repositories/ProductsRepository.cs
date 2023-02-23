using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class ProductsRepository : Repository<Product>, IProductsRepository
    {
        public ProductsRepository(InventoryContext dbContext) : base(dbContext)
        {
        }

        public Task<Product> GetProductByCompanyAndItemReferenceAsync(int companyId, int itemReference)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<Company, int>> GetProductsCountPerCompanyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<DateTime, IDictionary<Product, int>>> GetProductsCountPerDayPerProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<Product, int>> GetProductsCountPerProductByInventoryExternalIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}

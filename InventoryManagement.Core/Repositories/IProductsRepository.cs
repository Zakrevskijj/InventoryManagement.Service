using InventoryManagement.Core.Entities;

namespace InventoryManagement.Core.Repositories
{
    public interface IProductsRepository : IRepository<Product>
    {
        public Task<Product> GetProductByCompanyAndItemReferenceAsync(int companyId, int itemReference);
    }
}

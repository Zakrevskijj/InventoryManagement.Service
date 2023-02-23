using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class ProductsRepository : Repository<Product>, IProductsRepository
    {
        public ProductsRepository(InventoryContext dbContext) : base(dbContext)
        {
        }

        public async Task<Product> GetProductByCompanyAndItemReferenceAsync(int companyId, int itemReference)
        {
            return await _dbContext.Products
               .FirstOrDefaultAsync(x => x.CompanyId == companyId && x.ItemReference == itemReference);
        }

        public IDictionary<Company, int> GetProductsCountPerCompany()
        {
            var results = _dbContext.InventoryProducts
                .Include(x => x.Product.Company)
                .GroupBy(x => x.Product.Company)
                .ToList();

            var resultsDictionary = new Dictionary<Company, int>();
            foreach (var companyProductGroup in results)
            {
                var company = companyProductGroup.Key;
                int companyProductsCounter = 0;

                foreach (var inventoryProduct in companyProductGroup)
                {
                    companyProductsCounter += inventoryProduct.Count;
                }
                resultsDictionary.Add(company, companyProductsCounter);
            }

            return resultsDictionary;
        }

        public IDictionary<DateTime, IDictionary<Product, int>> GetProductsCountPerDayPerProduct()
        {
            var results = _dbContext.InventoryProducts
                .Include(x => x.Product)
                .Include(x => x.Inventory)
                .GroupBy(x => x.Inventory.DateTimeUtc.Date)
                .ToList();

            var resultsDictionary = new Dictionary<DateTime, IDictionary<Product, int>>();
            foreach (var dayProducts in results)
            {
                resultsDictionary.Add(dayProducts.Key, dayProducts.ToDictionary(x => x.Product, y => y.Count));
            }

            return resultsDictionary;
        }

        public IDictionary<Product, int> GetProductsCountPerProductByInventoryId(int inventoryId)
        {
            var inventoryProducts = _dbContext.InventoryProducts
                .Where(x => x.InventoryId == inventoryId)
                .Include(x => x.Product)
                .ToList();

            var resultsDictionary = new Dictionary<Product, int>();
            foreach (var inventoryProduct in inventoryProducts)
            {
                resultsDictionary.Add(inventoryProduct.Product, inventoryProduct.Count);
            }

            return resultsDictionary;
        }
    }
}

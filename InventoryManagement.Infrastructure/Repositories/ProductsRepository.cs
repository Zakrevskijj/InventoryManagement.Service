using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

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
            var results = _dbContext.Products
                .Include(x => x.Company)
                .GroupBy(x => x.Company)
                .ToList();

            var resultsDictionary = new Dictionary<Company, int>();
            foreach (var companyProductGroup in results)
            {
                resultsDictionary.Add(companyProductGroup.FirstOrDefault().Company, companyProductGroup.Count());
            }

            return resultsDictionary;
        }

        public IDictionary<DateTime, IDictionary<Product, int>> GetProductsCountPerDayPerProduct()
        {
            //var results = _dbContext.Products
            //    .Include(x => x.Company)
            //   .GroupBy(x => x.Company)
            //   .ToList();

            //var resultsDictionary = new Dictionary<Company, int>();
            //foreach (var companyProductGroup in results)
            //{
            //    resultsDictionary.Add(companyProductGroup.FirstOrDefault().Company, companyProductGroup.Count());
            //}

            //return resultsDictionary;
            throw new NotImplementedException();
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

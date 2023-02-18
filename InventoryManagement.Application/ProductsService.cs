using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Models;

namespace InventoryManagement.Application
{
    public class ProductsService : IProductsService
    {
        public Task<ProductModel> CreateProductAsync(ProductModel productModel)
        {
            throw new NotImplementedException();
        }
    }
}
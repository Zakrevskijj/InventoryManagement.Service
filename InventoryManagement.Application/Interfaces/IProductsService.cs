using InventoryManagement.Application.Models;

namespace InventoryManagement.Application.Interfaces
{
    public interface IProductsService
    {
        public Task<ProductModel> CreateProductAsync(ProductModel productModel);
    }
}

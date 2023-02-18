using InventoryManagement.Application.Models;

namespace InventoryManagement.Application.Interfaces
{
    public interface IProductsService
    {
        public ProductModel CreateProduct(CreateProductModel createProductModel);
    }
}

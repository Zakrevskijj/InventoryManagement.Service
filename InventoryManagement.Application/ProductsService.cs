using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Mapper;
using InventoryManagement.Application.Models;
using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;

namespace InventoryManagement.Application
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<ProductModel> CreateProductAsync(ProductModel productModel)
        {
            await ValidateIfProductExists(productModel);

            var newProduct = ObjectMapper.Mapper.Map<Product>(productModel);
            if (newProduct == null)
            {
                //ToDo: Throw good exception here
                throw new ApplicationException($"Unable to map");
            }

            var newProductEntity = await _productsRepository.AddAsync(newProduct);

            var newProductModel = ObjectMapper.Mapper.Map<ProductModel>(newProductEntity);
            return newProductModel;
        }

        private async Task ValidateIfProductExists(ProductModel productModel)
        {
            //ToDo: Check if product exists better here
            var existingEntity = await _productsRepository.GetByIdAsync(productModel.Id);
            if (existingEntity != null)
            {
                //ToDo: Throw good exception here
                throw new ApplicationException($"{productModel} with this id already exists");
            }
        }
    }
}
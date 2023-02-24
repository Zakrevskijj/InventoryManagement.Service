using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;
using Moq;

namespace InventoryManagement.Application.Tests
{
    public class ProductsServiceTests
    {
        private Mock<IProductsRepository> _mockProductsRepository;

        public ProductsServiceTests()
        {
            _mockProductsRepository = new Mock<IProductsRepository>();
        }

        [Fact]
        public async Task Create_New_Product_Validate_If_Exists()
        {
            var product = Product.Create(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<long>());

            _mockProductsRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);
            _mockProductsRepository.Setup(x => x.AddAsync(product)).ReturnsAsync(product);

            var productsService = new ProductsService(_mockProductsRepository.Object);

            await Assert.ThrowsAsync<ApplicationException>(async () =>
                await productsService.CreateProductAsync(new Models.ProductModel { Id = product.Id, Name = product.Name }));
        }
    }
}
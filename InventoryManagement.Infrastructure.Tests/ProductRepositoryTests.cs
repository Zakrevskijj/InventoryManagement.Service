using InventoryManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace InventoryManagement.Infrastructure.Tests
{
    public class ProductRepositoryTests
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ProductsRepository _productsRepository;
        private readonly ITestOutputHelper _output;
        private ProductBuilder ProductBuilder { get; } = new ProductBuilder();

        public ProductRepositoryTests(ITestOutputHelper output)
        {
            _output = output;
            var dbOptions = new DbContextOptionsBuilder<InventoryContext>()
                .UseInMemoryDatabase(databaseName: "InventoryDb")
                .Options;
            _inventoryContext = new InventoryContext(dbOptions);
            _productsRepository = new ProductsRepository(_inventoryContext);
        }

        [Fact]
        public async Task Get_Existing_Product()
        {
            var existingProduct = ProductBuilder.WithDefaultValues();
            _inventoryContext.Products.Add(existingProduct);
            _inventoryContext.SaveChanges();

            var productId = existingProduct.Id;
            _output.WriteLine($"ProductId: {productId}");

            var productFromRepo = await _productsRepository.GetByIdAsync(productId);
            Assert.Equal(ProductBuilder.TestProductId, productFromRepo.Id);
            Assert.Equal(ProductBuilder.TestCompanyId, productFromRepo.CompanyId);
        }
    }
}

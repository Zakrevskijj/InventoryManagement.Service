using InventoryManagement.Core.Entities;

namespace InventoryManagement.Infrastructure.Tests
{
    public class ProductBuilder
    {
        private Product _product;
        public int TestProductId => 3;
        public string TestProductName => "Test Product Name";
        public int TestCompanyId => 1;

        public long TestItemReference => 123456789;

        public ProductBuilder()
        {
            _product = WithDefaultValues();
        }

        public Product Build()
        {
            return _product;
        }

        public Product WithDefaultValues()
        {
            return Product.Create(TestProductId, TestCompanyId, TestProductName, TestItemReference);
        }
    }
}
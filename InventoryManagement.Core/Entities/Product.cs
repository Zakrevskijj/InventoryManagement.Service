namespace InventoryManagement.Core.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public long ItemReference { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public static Product Create(int productId, int companyId, string name, long itemReference)
        {
            var product = new Product
            {
                Id = productId,
                CompanyId = companyId,
                Name = name,
                ItemReference = itemReference
            };
            return product;
        }
    }
}

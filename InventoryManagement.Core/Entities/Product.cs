namespace InventoryManagement.Core.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public long ItemReference { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}

namespace InventoryManagement.Core.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public int ItemReference { get; set; }
        public Company Company { get; set; }
    }
}

namespace InventoryManagement.Core.Entities
{
    public class InventoryProduct : Entity
    {
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}

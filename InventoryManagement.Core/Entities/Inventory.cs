namespace InventoryManagement.Core.Entities
{
    public class Inventory : Entity
    {
        public DateTime DateTimeUtc { get; set; }
        public string ExternalId { get; set; }
        public string Location { get; set; }

        public ICollection<InventoryProduct> InventoryProducts { get; set; } = new List<InventoryProduct>();
    }
}

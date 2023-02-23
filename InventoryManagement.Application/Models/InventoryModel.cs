namespace InventoryManagement.Application.Models
{
    public class InventoryModel : BaseModel
    {
        public DateTime DateTimeUtc { get; set; }
        public string ExternalId { get; set; }
        public string Location { get; set; }
    }
}

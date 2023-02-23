namespace InventoryManagement.Api.Dtos
{
    public class CreateInventoryDto
    {
        public string ExternalId { get; set; }
        public string Location { get; set; }
        public ICollection<string> Tags { get; set; }
    }
}

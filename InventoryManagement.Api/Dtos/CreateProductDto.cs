namespace InventoryManagement.Api.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public int ItemReference { get; set; }
        public string CompanyName { get; set; }
        public string CompanyPrefix { get; set; }
    }
}

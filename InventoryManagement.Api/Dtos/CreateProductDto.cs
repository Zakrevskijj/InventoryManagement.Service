using InventoryManagement.Application.Models;

namespace InventoryManagement.Api.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public int ItemReference { get; set; }
        public CompanyModel Company { get; set; }
    }
}

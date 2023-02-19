using System;
namespace InventoryManagement.Application.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public int ItemReference { get; set; }

        public CompanyModel Company { get; set; }
    }
}

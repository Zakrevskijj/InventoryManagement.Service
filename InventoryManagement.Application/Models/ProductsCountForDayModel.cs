namespace InventoryManagement.Application.Models
{
    public class ProductsCountForDayModel
    {
        public DateTime Date { get; set; }
        public ICollection<ProductCountModel> Products { get; set; }
    }
}

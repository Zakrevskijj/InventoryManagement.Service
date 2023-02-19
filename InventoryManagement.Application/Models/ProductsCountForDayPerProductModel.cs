namespace InventoryManagement.Application.Models
{
    public class ProductsCountForDayPerProductModel
    {
        public DateTime Date { get; set; }
        public ICollection<ProductCountModel> Products { get; set; }
    }
}

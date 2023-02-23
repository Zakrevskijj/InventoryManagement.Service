using InventoryManagement.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Infrastructure
{
    public class InventoryContextSeed
    {
        public static async Task SeedAsync(InventoryContext inventoryContext, IProductsService productsService)
        {
            try
            {
                // Uncomment for real DB case
                inventoryContext.Database.Migrate();
                inventoryContext.Database.EnsureCreated();

                if (!inventoryContext.Products.Any())
                {
                    var productsFromFile = File.ReadAllLines("..\\InventoryManagement.Infrastructure\\data.csv");
                    for (var i = 1; i < productsFromFile.Length; i++)
                    {
                        var productFields = productsFromFile[i].Split(';');
                        await productsService.CreateProductAsync(new Application.Models.ProductModel
                        {
                            Company = new Application.Models.CompanyModel
                            {
                                Prefix = long.Parse(productFields[0]),
                                Name = productFields[1]
                            },
                            ItemReference = int.Parse(productFields[2]),
                            Name = productFields[3]
                        });
                    }
                }
            }
            catch
            {
                //Log here
                throw;
            }
        }
    }
}

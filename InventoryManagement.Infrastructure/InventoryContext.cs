using InventoryManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<InventoryProduct> InventoryProducts { get; set; }
    }
}
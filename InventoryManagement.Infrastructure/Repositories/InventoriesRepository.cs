using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class InventoriesRepository : Repository<Inventory>, IInventoriesRepository
    {
        public InventoriesRepository(InventoryContext dbContext) : base(dbContext)
        {
        }
    }
}

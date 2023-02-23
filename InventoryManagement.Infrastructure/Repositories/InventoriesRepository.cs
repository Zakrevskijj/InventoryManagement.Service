using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class InventoriesRepository : Repository<Inventory>, IInventoriesRepository
    {
        public InventoriesRepository(InventoryContext dbContext) : base(dbContext)
        {
        }

        public async Task<Inventory> GetInventoryByExternalIdAsync(string externalId)
        {
            return await _dbContext.Inventories.FirstOrDefaultAsync(x => x.ExternalId == externalId);
        }
    }
}

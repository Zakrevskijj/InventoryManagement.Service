using InventoryManagement.Core.Entities;

namespace InventoryManagement.Core.Repositories
{
    public interface IInventoriesRepository : IRepository<Inventory>
    {
        public Task<Inventory> GetInventoryByExternalIdAsync(string externalId);
    }
}

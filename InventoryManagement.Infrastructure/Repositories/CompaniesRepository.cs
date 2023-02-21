using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class CompaniesRepository : Repository<Company>, ICompaniesRepository
    {
        public CompaniesRepository(InventoryContext dbContext) : base(dbContext)
        {
        }

        public Task<Company> GetCompanyByPrefixAsync(int companyPrefix)
        {
            throw new NotImplementedException();
        }
    }
}

using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class CompaniesRepository : Repository<Company>, ICompaniesRepository
    {
        public CompaniesRepository(InventoryContext dbContext) : base(dbContext)
        {
        }

        public async Task<Company> GetCompanyByPrefixAsync(long companyPrefix)
        {
            return await _dbContext.Companies
                .FirstOrDefaultAsync(x => x.Prefix == companyPrefix);
        }
    }
}

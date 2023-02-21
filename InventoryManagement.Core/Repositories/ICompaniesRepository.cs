using InventoryManagement.Core.Entities;
namespace InventoryManagement.Core.Repositories
{
    public interface ICompaniesRepository : IRepository<Company>
    {
        Task<Company> GetCompanyByPrefixAsync(int companyPrefix);
    }
}

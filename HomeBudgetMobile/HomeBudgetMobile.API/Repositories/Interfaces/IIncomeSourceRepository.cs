using HomeBudgetMobile.API.Model.Domain;

namespace HomeBudgetMobile.API.Repositories.Interfaces
{
    public interface IIncomeSourceRepository
    {
        Task<List<IncomeSource>> GetAllAsync();
        Task<IncomeSource?> GetByIdAsync(Guid id);
        Task<IncomeSource> CreateAsync(IncomeSource incomeSource);
        Task<IncomeSource?> UpdateAsync(Guid id, IncomeSource incomeSource);
        Task<IncomeSource?> DeleteAsync(Guid id);
    }
}

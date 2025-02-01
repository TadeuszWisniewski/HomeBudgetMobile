using HomeBudgetMobile.API.Model.Domain;

namespace HomeBudgetMobile.API.Repositories.Interfaces
{
    public interface IIncomeRepository
    {
        Task<List<Income>> GetAllAsync();
        Task<Income?> GetByIdAsync(Guid id);
        Task<Income> CreateAsync(Income income);
        Task<Income?> UpdateAsync(Guid id,Income income);
        Task<Income?> DeleteByIdAsync(Guid id);
    }
}

using HomeBudgetMobile.API.Model.Domain;

namespace HomeBudgetMobile.API.Repositories.Interfaces
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetAllAsync();
        Task<Expense?> GetByIdAsync(Guid id);
        Task<Expense> CreateAsync(Expense expense);
        Task<Expense?> UpdateAsync(Guid id ,Expense expense);
        Task<Expense?> DeleteAsync(Guid id);
    }
}

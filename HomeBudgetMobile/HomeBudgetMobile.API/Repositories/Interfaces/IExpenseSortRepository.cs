using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Model.DTO.ExpenseSort;

namespace HomeBudgetMobile.API.Repositories.Interfaces
{
    public interface IExpenseSortRepository
    {
        Task<List<ExpenseSort>> GetAllAsync();
        Task<ExpenseSort?> GetByIdAsync(Guid id);
        Task<ExpenseSort> CreateAsync(ExpenseSort expenseSort);
        Task<ExpenseSort?> UpdateAsync(Guid id, ExpenseSort expenseSort);
        Task<ExpenseSort?> DeleteAsync(Guid id);
    }
}

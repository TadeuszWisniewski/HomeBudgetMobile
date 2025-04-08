using HomeBudgetMobile.API.Data;
using HomeBudgetMobile.API.Model.Domain;

namespace HomeBudgetMobile.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);
        Task<User> CreateAsync(User user);
        Task<User?> UpdateAsync(Guid id, Guid[] guids);
        Task<User?> DeleteAsync(Guid id);
        Task<User?> AddIncomeToUser(Guid id, Guid idIncome);
        Task<User?> AddExpenseToUser(Guid id, Guid idExpense);
        Task<User?> AddSavingToUser(Guid id, Guid idSaving);
    }
}

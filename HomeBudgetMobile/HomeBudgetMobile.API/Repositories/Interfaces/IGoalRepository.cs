using HomeBudgetMobile.API.Model.Domain;

namespace HomeBudgetMobile.API.Repositories.Interfaces
{
    public interface IGoalRepository
    {
        Task<List<Goal>> GetAllAsync();
        Task<Goal?> GetByIdAsync(Guid id);
        Task<Goal> CreateAsync(Goal goal);
        Task<Goal?> UpdateAsync(Guid id, Goal goal);
        Task<Goal?> DeleteAsync(Guid id);
    }
}

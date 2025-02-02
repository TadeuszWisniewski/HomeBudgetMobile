using HomeBudgetMobile.API.Model.Domain;

namespace HomeBudgetMobile.API.Repositories.Interfaces
{
    public interface ISavingRepository
    {
        Task<List<Saving>> GetAllAsync();
        Task<Saving?> GetByIdAsync(Guid id);
        Task<Saving> CreateAsync(Saving saving);
        Task<Saving?> UpdateAsync(Guid id, Saving saving);
        Task<Saving?> DeleteAsync(Guid id);
    }
}

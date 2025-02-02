using HomeBudgetMobile.API.Data;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Repositories
{
    public class SQLSavingRepository : ISavingRepository
    {
        private readonly HomeBudgetMobileDbContext homeBudgetMobileDbContext;

        public SQLSavingRepository(HomeBudgetMobileDbContext homeBudgetMobileDbContext)
        {
            this.homeBudgetMobileDbContext = homeBudgetMobileDbContext;
        }
        public async Task<Saving> CreateAsync(Saving saving)
        {
            await homeBudgetMobileDbContext.AddAsync(saving);
            await homeBudgetMobileDbContext.SaveChangesAsync();

            return saving;
        }

        public async Task<Saving?> DeleteAsync(Guid id)
        {
            var existingSaving = await homeBudgetMobileDbContext.Savings.FirstOrDefaultAsync(s => s.Id == id);

            if (existingSaving == null)
            {
                return null;
            }

            homeBudgetMobileDbContext.Savings.Remove(existingSaving);
            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingSaving;
        }

        public async Task<List<Saving>> GetAllAsync()
        {
            return await homeBudgetMobileDbContext.Savings.ToListAsync();
        }

        public async Task<Saving?> GetByIdAsync(Guid id)
        {
            return await homeBudgetMobileDbContext.Savings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Saving?> UpdateAsync(Guid id, Saving saving)
        {
            var existingSaving = await homeBudgetMobileDbContext.Savings.FirstOrDefaultAsync();

            if (existingSaving == null)
            {
                return null;
            }

            existingSaving.Amount = saving.Amount;
            existingSaving.Currency = saving.Currency;
            existingSaving.Description = saving.Description;
            existingSaving.IsActive = saving.IsActive;
            existingSaving.GoalId = saving.GoalId;

            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingSaving;
        }
    }
}

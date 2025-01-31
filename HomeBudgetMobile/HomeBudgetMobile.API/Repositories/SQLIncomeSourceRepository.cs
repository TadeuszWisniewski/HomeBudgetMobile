using HomeBudgetMobile.API.Data;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Repositories
{
    public class SqlIncomeSourceRepository : IIncomeSourceRepository
    {
        private readonly HomeBudgetMobileDbContext homeBudgetMobileDbContext;

        public SqlIncomeSourceRepository(HomeBudgetMobileDbContext homeBudgetMobileDbContext)
        {
            this.homeBudgetMobileDbContext = homeBudgetMobileDbContext;
        }

        public async Task<IncomeSource> CreateAsync(IncomeSource incomeSource)
        {
            await homeBudgetMobileDbContext.IncomeSources.AddAsync(incomeSource);
            await homeBudgetMobileDbContext.SaveChangesAsync();

            return incomeSource;
        }

        public async Task<IncomeSource?> DeleteAsync(Guid id)
        {
            var existingIncomeSource = await homeBudgetMobileDbContext.IncomeSources.FirstOrDefaultAsync(x => x.Id == id);

            if (existingIncomeSource == null)
            {
                return null;
            }

            homeBudgetMobileDbContext.IncomeSources.Remove(existingIncomeSource);
            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingIncomeSource;
        }

        public async Task<List<IncomeSource>> GetAllAsync()
        {
            return await homeBudgetMobileDbContext.IncomeSources.ToListAsync();
        }

        public async Task<IncomeSource?> GetByIdAsync(Guid id)
        {
            return await homeBudgetMobileDbContext.IncomeSources.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IncomeSource?> UpdateAsync(Guid id, IncomeSource incomeSource)
        {
            var existingIncomeSource = await homeBudgetMobileDbContext.IncomeSources.FirstOrDefaultAsync(x => x.Id == id);

            if (existingIncomeSource == null)
            {
                return null;
            }

            existingIncomeSource.Name = incomeSource.Name;
            existingIncomeSource.Description = incomeSource.Description;
            existingIncomeSource.IsActive = incomeSource.IsActive;

            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingIncomeSource;
        }
    }
}

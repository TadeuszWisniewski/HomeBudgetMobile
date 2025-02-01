using HomeBudgetMobile.API.Data;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Repositories
{
    public class SQLIncomeRepository : IIncomeRepository
    {
        private readonly HomeBudgetMobileDbContext homeBudgetMobileDbContext;

        public SQLIncomeRepository(HomeBudgetMobileDbContext homeBudgetMobileDbContext)
        {
            this.homeBudgetMobileDbContext = homeBudgetMobileDbContext;
        }
        public async Task<Income> CreateAsync(Income income)
        {
            await homeBudgetMobileDbContext.AddAsync(income);
            await homeBudgetMobileDbContext.SaveChangesAsync();

            return income;
        }

        public async Task<Income?> DeleteByIdAsync(Guid id)
        {
            var existingIncome = await homeBudgetMobileDbContext.Incomes.FirstOrDefaultAsync(x => x.Id == id);

            if (existingIncome == null)
            {
                return null;
            }

            homeBudgetMobileDbContext.Incomes.Remove(existingIncome);
            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingIncome;
        }

        public async Task<List<Income>> GetAllAsync()
        {
            return await homeBudgetMobileDbContext.Incomes.Include("IncomeSource").ToListAsync();
        }

        public async Task<Income?> GetByIdAsync(Guid id)
        {
            return await homeBudgetMobileDbContext.Incomes.Include("IncomeSource").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Income?> UpdateAsync(Guid id, Income income)
        {
            var existingIncome = await homeBudgetMobileDbContext.Incomes.FirstOrDefaultAsync(x => x.Id == id);

            if (existingIncome == null)
            {
                return null;
            }

            existingIncome.Amount = income.Amount;
            existingIncome.Currency = income.Currency;
            existingIncome.Description = income.Description;
            existingIncome.IsActive = income.IsActive;
            existingIncome.IncomeSourceId = income.IncomeSourceId;

            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingIncome;
        }
    }
}

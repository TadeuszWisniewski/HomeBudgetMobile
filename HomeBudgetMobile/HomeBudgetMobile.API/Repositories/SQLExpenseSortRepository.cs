using HomeBudgetMobile.API.Data;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Repositories
{
    public class SQLExpenseSortRepository : IExpenseSortRepository
    {
        private readonly HomeBudgetMobileDbContext homeBudgetMobileDbContext;

        public SQLExpenseSortRepository(HomeBudgetMobileDbContext homeBudgetMobileDbContext)
        {
            this.homeBudgetMobileDbContext = homeBudgetMobileDbContext;
        }
        public async Task<ExpenseSort> CreateAsync(ExpenseSort expenseSort)
        {
            await homeBudgetMobileDbContext.ExpenseSorts.AddAsync(expenseSort);
            await homeBudgetMobileDbContext.SaveChangesAsync();

            return expenseSort;
        }

        public async Task<ExpenseSort?> DeleteAsync(Guid id)
        {
            var existingExpenseSort = await homeBudgetMobileDbContext.ExpenseSorts.FirstOrDefaultAsync(x => x.Id == id);

            if (existingExpenseSort == null)
            {
                return null;
            }

            homeBudgetMobileDbContext.Remove(existingExpenseSort);
            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingExpenseSort;
        }

        public async Task<List<ExpenseSort>> GetAllAsync()
        {
            return await homeBudgetMobileDbContext.ExpenseSorts.Include(x => x.Expenses).ToListAsync();
        }

        public async Task<ExpenseSort?> GetByIdAsync(Guid id)
        {
            return await homeBudgetMobileDbContext.ExpenseSorts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ExpenseSort?> UpdateAsync(Guid id, ExpenseSort expenseSort)
        {
            var existingExpenseSort = await homeBudgetMobileDbContext.ExpenseSorts.FirstOrDefaultAsync(x => x.Id == id);

            if (existingExpenseSort == null)
            {
                return null;
            }

            existingExpenseSort.Name = expenseSort.Name;
            existingExpenseSort.Description = expenseSort.Description;
            existingExpenseSort.IsActive = expenseSort.IsActive;

            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingExpenseSort;
        }
    }
}

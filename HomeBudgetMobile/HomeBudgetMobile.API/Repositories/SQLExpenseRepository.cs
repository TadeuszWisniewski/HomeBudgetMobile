using HomeBudgetMobile.API.Data;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Repositories
{
    public class SQLExpenseRepository : IExpenseRepository
    {
        private readonly HomeBudgetMobileDbContext homeBudgetMobileDbContext;

        public SQLExpenseRepository(HomeBudgetMobileDbContext homeBudgetMobileDbContext)
        {
            this.homeBudgetMobileDbContext = homeBudgetMobileDbContext;
        }
        public async Task<Expense> CreateAsync(Expense expense)
        {
            await homeBudgetMobileDbContext.Expenses.AddAsync(expense);
            await homeBudgetMobileDbContext.SaveChangesAsync();

            return expense;
        }

        public async Task<Expense?> DeleteAsync(Guid id)
        {
            var existingExpense = await homeBudgetMobileDbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);

            if (existingExpense == null)
            {
                return null;
            }

            homeBudgetMobileDbContext.Expenses.Remove(existingExpense);
            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingExpense;
        }

        public async Task<List<Expense>> GetAllAsync()
        {
            return await homeBudgetMobileDbContext.Expenses.Include(x => x.ExpenseSort).ToListAsync();
        }

        public async Task<Expense?> GetByIdAsync(Guid id)
        {
            return await homeBudgetMobileDbContext.Expenses.Include(x => x.ExpenseSort).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Expense?> UpdateAsync(Guid id, Expense expense)
        {
            var existingExpense = await homeBudgetMobileDbContext.Expenses.FirstOrDefaultAsync(x => x.Id == id);

            if (existingExpense == null)
            {
                return null;
            }

            existingExpense.Amount = expense.Amount;
            existingExpense.Currency = expense.Currency;
            existingExpense.Description = expense.Description;
            existingExpense.IsActive = expense.IsActive;
            existingExpense.ExpenseSortId = expense.ExpenseSortId;

            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingExpense;
        }
    }
}

using HomeBudgetMobile.API.Data;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly HomeBudgetMobileDbContext homeBudgetMobileDbContext;

        public SQLUserRepository(HomeBudgetMobileDbContext homeBudgetMobileDbContext)
        {
            this.homeBudgetMobileDbContext = homeBudgetMobileDbContext;
        }
        public async Task<User> CreateAsync(User user)
        {
            await homeBudgetMobileDbContext.AddAsync(user);
            await homeBudgetMobileDbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteAsync(Guid id)
        {
            var existingUser = await homeBudgetMobileDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            homeBudgetMobileDbContext.Users.Remove(existingUser);
            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingUser;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await homeBudgetMobileDbContext.Users.Include(e => e.Expenses).Include(e => e.Savings).Include(e => e.Incomes).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await homeBudgetMobileDbContext.Users.Include(e => e.Expenses).Include(e => e.Savings).Include(e => e.Incomes).FirstOrDefaultAsync(x =>x.Id == id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            //var check = await homeBudgetMobileDbContext
            return await homeBudgetMobileDbContext.Users.Include(e => e.Expenses).Include(e => e.Savings).Include(e => e.Incomes).FirstOrDefaultAsync(x => ((x.Email).Trim()).Equals(email.Trim()));
        }

        public async Task<User?> UpdateAsync(Guid id, Guid[] guids)
        {
            var existingUser = await homeBudgetMobileDbContext.Users.Include(e => e.Expenses).Include(e => e.Savings).Include(e => e.Incomes).FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            //if (user != null) 
            //{
            //    existingUser.Name = user.Name;
            //    existingUser.Email = user.Email;
            //    existingUser.Password = user.Password;
            //    existingUser.Description = user.Description;
            //    existingUser.IsActive = user.IsActive;
            //}

            if (guids[0] != Guid.Empty)
            {
                var incomeToAdd = await homeBudgetMobileDbContext.Incomes.FirstOrDefaultAsync(x => x.Id == guids[0]);
                if (incomeToAdd == null)
                {
                    return null;
                }
                existingUser.Incomes.Add(incomeToAdd);
            }

            if (guids[1] != Guid.Empty)
            {
                var expenseToAdd = await homeBudgetMobileDbContext.Expenses.FirstOrDefaultAsync(x => x.Id == guids[1]);
                if (expenseToAdd == null)
                {
                    return null;
                }
                existingUser.Expenses.Add(expenseToAdd);
            }

            if (guids[2] != Guid.Empty)
            {
                var savingToAdd = await homeBudgetMobileDbContext.Savings.FirstOrDefaultAsync(x => x.Id == guids[2]);
                if (savingToAdd == null)
                {
                    return null;
                }
                existingUser.Savings.Add(savingToAdd);
            }

            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingUser;
        }

        public async Task<User?> AddIncomeToUser(Guid id, Guid idIncome)
        {
            var existingUser = await homeBudgetMobileDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            var existingIncome = await homeBudgetMobileDbContext.Incomes.FirstOrDefaultAsync(x => x.Id == idIncome);

            if (existingIncome == null)
            {
                return null;
            }

            existingUser.Incomes.Add(existingIncome);

            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingUser;
        }

        public async Task<User?> AddExpenseToUser(Guid id, Guid idExpense)
        {
            var existingUser = await homeBudgetMobileDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            var existingExpense = await homeBudgetMobileDbContext.Expenses.FirstOrDefaultAsync(x => x.Id == idExpense);

            if (existingExpense == null)
            {
                return null;
            }

            existingUser.Expenses.Add(existingExpense);

            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingUser;
        }

        public async Task<User?> AddSavingToUser(Guid id, Guid idSaving)
        {
            var existingUser = await homeBudgetMobileDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            var existingSaving = await homeBudgetMobileDbContext.Savings.FirstOrDefaultAsync(x => x.Id == idSaving);

            if (existingSaving == null)
            {
                return null;
            }

            existingUser.Savings.Add(existingSaving);

            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingUser;
        }
    }
}

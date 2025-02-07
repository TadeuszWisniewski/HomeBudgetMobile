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
            return await homeBudgetMobileDbContext.Users.Include(e => e.Expenses).Include(e => e.Savings).Include(e => e.Incomes). ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await homeBudgetMobileDbContext.Users.FirstOrDefaultAsync(x =>x.Id == id);
        }

        public async Task<User?> UpdateAsync(Guid id, User user)
        {
            var existingUser = await homeBudgetMobileDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.Name = user.Name;
            existingUser.Surname = user.Surname;
            existingUser.Description = user.Description;
            existingUser.IsActive = user.IsActive;

            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingUser;
        }
    }
}

using HomeBudgetMobile.API.Data;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Repositories
{
    public class SQLGoalRepository : IGoalRepository
    {
        private readonly HomeBudgetMobileDbContext homeBudgetMobileDbContext;

        public SQLGoalRepository(HomeBudgetMobileDbContext homeBudgetMobileDbContext)
        {
            this.homeBudgetMobileDbContext = homeBudgetMobileDbContext;
        }
        public async Task<Goal> CreateAsync(Goal goal)
        {
            await homeBudgetMobileDbContext.Goals.AddAsync(goal);
            await homeBudgetMobileDbContext.SaveChangesAsync();

            return goal;
        }

        public async Task<Goal?> DeleteAsync(Guid id)
        {
            var existingGoal = await homeBudgetMobileDbContext.Goals.FirstOrDefaultAsync(x => x.Id == id);

            if (existingGoal == null)
            {
                return null;
            }

            homeBudgetMobileDbContext.Goals.Remove(existingGoal);
            await homeBudgetMobileDbContext.SaveChangesAsync();

            return existingGoal;
        }

        public async Task<List<Goal>> GetAllAsync()
        {
            return await homeBudgetMobileDbContext.Goals.ToListAsync();
        }

        public async Task<Goal?> GetByIdAsync(Guid id)
        {
            return await homeBudgetMobileDbContext.Goals.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Goal?> UpdateAsync(Guid id, Goal goal)
        {
            var existingGoal = await homeBudgetMobileDbContext.Goals.FirstOrDefaultAsync(x => x.Id == id);

            if(existingGoal == null)
            {
                return null;
            }

            existingGoal.Name = goal.Name;
            existingGoal.NeededAmount = goal.NeededAmount;
            existingGoal.Currency = goal.Currency;
            existingGoal.StartDate = goal.StartDate;
            existingGoal.EndDate = goal.EndDate;
            existingGoal.Description = goal.Description;
            existingGoal.IsAcive = goal.IsAcive;

            await homeBudgetMobileDbContext.SaveChangesAsync();
            return existingGoal;
        }
    }
}

using HomeBudgetMobile.API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API.Data
{
    public class HomeBudgetMobileDbContext : DbContext
    {
        public HomeBudgetMobileDbContext(DbContextOptions<HomeBudgetMobileDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        
        public DbSet<IncomeSource> IncomeSources { get; set; }
        public DbSet<ExpenseSort> ExpenseSorts { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Saving> Savings { get; set; }
        public DbSet<User> Users { get; set; }

        // Seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var incomeSources = new List<IncomeSource>()
            {
                new IncomeSource()
                {
                    Id = Guid.Parse("57272e05-a899-4c71-8d5e-6496ead7f72e"),
                    Name = "Salary",
                    Description = "This is the first IncomeSource"
                }
            };

            // Seed first IncomeSource to the database
            modelBuilder.Entity<IncomeSource>().HasData(incomeSources);
        }
    }
}

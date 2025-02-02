using HomeBudgetMobile.API.Data;
using HomeBudgetMobile.API.Mappings;
using HomeBudgetMobile.API.Repositories;
using HomeBudgetMobile.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetMobile.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<HomeBudgetMobileDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("HomeBudgetMobileConnectionString")));

            builder.Services.AddAutoMapper(typeof(AutomapperProfiles));

            builder.Services.AddScoped<IIncomeSourceRepository, SqlIncomeSourceRepository>();
            builder.Services.AddScoped<IExpenseSortRepository, SQLExpenseSortRepository>();
            builder.Services.AddScoped<IGoalRepository, SQLGoalRepository>();
            builder.Services.AddScoped<IIncomeRepository, SQLIncomeRepository>();
            builder.Services.AddScoped<IExpenseRepository, SQLExpenseRepository>();
            builder.Services.AddScoped<ISavingRepository, SQLSavingRepository>();
           

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

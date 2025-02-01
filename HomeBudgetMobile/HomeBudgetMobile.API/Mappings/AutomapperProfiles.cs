using AutoMapper;
using HomeBudgetMobile.API.Model.Domain;
using HomeBudgetMobile.API.Model.DTO.ExpenseSort;
using HomeBudgetMobile.API.Model.DTO.Goal;
using HomeBudgetMobile.API.Model.DTO.IncomeSource;

namespace HomeBudgetMobile.API.Mappings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<IncomeSource, IncomeSourceDto>().ReverseMap();
            CreateMap<IncomeSource, UpdateIncomeSourceDto>().ReverseMap();
            CreateMap<IncomeSource, CreateIncomeSourceDto>().ReverseMap();

            CreateMap<ExpenseSort, ExpenseSortDto>().ReverseMap();
            CreateMap<ExpenseSort, UpdateExpenseSortDto>().ReverseMap();
            CreateMap<ExpenseSort, CreateExpenseSortDto>().ReverseMap();

            CreateMap<Goal, GoalDto>().ReverseMap();
            CreateMap<Goal, CreateGoalDto>().ReverseMap();
            CreateMap<Goal, UpdateGoalDto>().ReverseMap();
        }
    }
}

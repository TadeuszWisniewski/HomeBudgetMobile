using AutoMapper;
using HomeBudgetMobile.API.Model.Domain;
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
        }
    }
}

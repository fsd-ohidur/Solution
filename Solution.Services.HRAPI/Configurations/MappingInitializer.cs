using AutoMapper;
using Solution.Services.HRAPI.Domain;
using Solution.Services.HRAPI.Models;

namespace Solution.Services.HRAPI.Configurations
{
    public class MappingInitializer:Profile
    {
        public MappingInitializer()
        {
                CreateMap<Company, CompanyDto>().ReverseMap();
                CreateMap<Company, CreateCompanyDto>().ReverseMap();
        }
    }
}

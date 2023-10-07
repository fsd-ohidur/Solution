using AutoMapper;
using Solution.Core.Models.Common.Domain;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Domain;
using Solution.Core.Models.HR.Dto;
using Solution.Core.Models.Test.Domain;
using Solution.Core.Models.Test.Dto;

namespace Solution.Services.HRAPI.Configurations
{
    public class MappingInitializer : Profile
	{
		public MappingInitializer()
		{
			CreateMap<Company, CompanyDto>().ReverseMap();
			CreateMap<Company, CreateCompanyDto>().ReverseMap();
			CreateMap<Department, DepartmentDto>().ReverseMap();
			CreateMap<Department, CreateDepartmentDto>().ReverseMap();
			CreateMap<Designation, DesignationDto>().ReverseMap();
			CreateMap<Designation, CreateDesignationDto>().ReverseMap();
			CreateMap<CommonData, CommonDataDto>().ReverseMap();
			CreateMap<CommonData, CreateCommonDataDto>().ReverseMap();
			CreateMap<Shift, ShiftDto>().ReverseMap();
			CreateMap<Shift, CreateShiftDto>().ReverseMap();
			CreateMap<Employee, EmployeeDto>().ReverseMap();
			CreateMap<Employee, CreateEmployeeDto>().ReverseMap();


			CreateMap<TestParent, TestParentDto>().ReverseMap();
			CreateMap<TestParent, CreateTestParentDto>().ReverseMap();

			CreateMap<TestChild, TestChildDto>().ReverseMap();
			CreateMap<TestChild, CreateTestChildDto>().ReverseMap();

		}
	}
}

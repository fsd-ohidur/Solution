using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Dto;
using Solution.Core.Models.Test.Domain;
using Solution.Core.Models.Test.Dto;

namespace Solution.Web.HR.Services.IServices
{
	public interface IUnitOfService : IDisposable
	{
		IGenericService<CompanyDto, ResponseDto> Companies { get; }
		IGenericService<DepartmentDto, ResponseDto> Departments { get; }
		IGenericService<DesignationDto, ResponseDto> Designations { get; }
		IGenericService<ShiftDto, ResponseDto> Shifts { get; }
		IGenericService<CommonDataDto, ResponseDto> CommonDatas { get; }
		IGenericService<EmployeeDto, ResponseDto> Employees { get; }
		//IGenericService<Attendance, ResponseDto> Attendances { get; }

		IGenericService<TestParentDto, ResponseDto> TestParents { get; }
		IGenericService<TestChildDto, ResponseDto> TestChilds { get; }

	}
}

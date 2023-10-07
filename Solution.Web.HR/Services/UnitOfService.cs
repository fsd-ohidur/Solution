using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Domain;
using Solution.Core.Models.HR.Dto;
using Solution.Core.Models.Test.Dto;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Services
{
	public class UnitOfService : IUnitOfService
	{
		public IHttpClientFactory _context { get; set; }

		private GenericService<CompanyDto, ResponseDto> _Companies;
		private GenericService<DepartmentDto, ResponseDto> _Departments;
		private GenericService<DesignationDto, ResponseDto> _Designations;
		private GenericService<ShiftDto, ResponseDto> _Shifts;
		private GenericService<CommonDataDto, ResponseDto> _CommonDatas;
		private GenericService<EmployeeDto, ResponseDto> _Employees;
		private GenericService<TestParentDto, ResponseDto> _TestParent;
		private GenericService<TestChildDto, ResponseDto> _TestChild;

		public UnitOfService(IHttpClientFactory context)
		{
			_context = context;
		}

		public IGenericService<CompanyDto, ResponseDto> Companies => _Companies ??= new GenericService<CompanyDto, ResponseDto>(_context);
		public IGenericService<DepartmentDto, ResponseDto> Departments => _Departments ??= new GenericService<DepartmentDto, ResponseDto>(_context);
		public IGenericService<DesignationDto, ResponseDto> Designations => _Designations ??= new GenericService<DesignationDto, ResponseDto>(_context);
		public IGenericService<ShiftDto, ResponseDto> Shifts => _Shifts ??= new GenericService<ShiftDto, ResponseDto>(_context);
		public IGenericService<CommonDataDto, ResponseDto> CommonDatas => _CommonDatas ??= new GenericService<CommonDataDto, ResponseDto>(_context);
		public IGenericService<EmployeeDto, ResponseDto> Employees => _Employees ??= new GenericService<EmployeeDto, ResponseDto>(_context);
		public IGenericService<TestParentDto, ResponseDto> TestParents => _TestParent ??= new GenericService<TestParentDto, ResponseDto>(_context);
		public IGenericService<TestChildDto, ResponseDto> TestChilds => _TestChild ??= new GenericService<TestChildDto, ResponseDto>(_context);

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}

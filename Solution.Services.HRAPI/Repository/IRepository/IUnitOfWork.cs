
using Solution.Core.Models.Common.Domain;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Domain;
using Solution.Core.Models.Test.Domain;

namespace Solution.Services.HRAPI.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<Company> Companies { get; }
		IGenericRepository<Department> Departments { get; }
		IGenericRepository<Designation> Designations { get; }
		IGenericRepository<Shift> Shifts { get; }
		IGenericRepository<CommonData> CommonDatas { get; }
		IGenericRepository<Employee> Employees { get; }
		IGenericRepository<Attendance> Attendances { get; }
		IGenericRepository<TestParent> TestParents { get; }
		IGenericRepository<TestChild> TestChilds { get; }
		Task SaveAsync();
	}
}

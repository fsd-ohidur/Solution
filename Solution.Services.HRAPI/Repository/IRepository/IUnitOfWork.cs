using Solution.Services.HRAPI.Domain;
using Solution.Services.HRAPI.Models;

namespace Solution.Services.HRAPI.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<Company> Companies { get; }
		IGenericRepository<Department> Departments { get; }
		IGenericRepository<Designation> Designations { get; }
		IGenericRepository<Shift> Shifts { get; }
		IGenericRepository<Gender> Genders { get; }
		IGenericRepository<Employee> Employees { get; }
		IGenericRepository<Attendance> Attendances { get; }
		Task SaveAsync();
	}
}

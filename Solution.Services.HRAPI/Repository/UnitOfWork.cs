using Solution.Services.HRAPI.Data;
using Solution.Services.HRAPI.Domain;
using Solution.Services.HRAPI.Models;
using Solution.Services.HRAPI.Repository.IRepository;

namespace Solution.Services.HRAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _context;

		private GenericRepository<Company> _Companies;
		private GenericRepository<Department> _Departments;
		private GenericRepository<Shift> _Shifts;
		private GenericRepository<Designation> _Designations;
		private GenericRepository<Gender> _Genders;
		private GenericRepository<Employee> _Employees;
		private GenericRepository<Attendance> _Attendances;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
		}
		public IGenericRepository<Company> Companies => _Companies??=new GenericRepository<Company>(_context);

		public IGenericRepository<Department> Departments => _Departments??=new GenericRepository<Department>(_context);

		public IGenericRepository<Designation> Designations => _Designations ??= new GenericRepository<Designation>(_context);

		public IGenericRepository<Shift> Shifts => _Shifts ??= new GenericRepository<Shift>(_context);

		public IGenericRepository<Gender> Genders => _Genders ??= new GenericRepository<Gender>(_context);

		public IGenericRepository<Employee> Employees => _Employees ??= new GenericRepository<Employee>(_context);

		public IGenericRepository<Attendance> Attendances => _Attendances ??= new GenericRepository<Attendance>(_context);

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		private void Dispose(bool dispose)
		{
			if (dispose)
			{
				_context.Dispose();
			}
		}
		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}

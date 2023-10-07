
using Solution.Core.Models.Common.Domain;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Domain;
using Solution.Core.Models.Test;
using Solution.Core.Models.Test.Domain;
using Solution.Services.HRAPI.Data;
using Solution.Services.HRAPI.Repository;
using Solution.Services.HRAPI.Repository.IRepository;

namespace Solution.Core.Models
{
    public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _context;

		private GenericRepository<Company> _Companies;
		private GenericRepository<Department> _Departments;
		private GenericRepository<Shift> _Shifts;
		private GenericRepository<Designation> _Designations;
		private GenericRepository<CommonData> _CommonDatas;
		private GenericRepository<Employee> _Employees;
		private GenericRepository<Attendance> _Attendances;
		private GenericRepository<TestParent> _TestParents;
		private GenericRepository<TestChild> _TestChilds;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
		}
		public IGenericRepository<Company> Companies => _Companies??=new GenericRepository<Company>(_context);
		public IGenericRepository<Department> Departments => _Departments??=new GenericRepository<Department>(_context);
		public IGenericRepository<Designation> Designations => _Designations ??= new GenericRepository<Designation>(_context);
		public IGenericRepository<Shift> Shifts => _Shifts ??= new GenericRepository<Shift>(_context);
		public IGenericRepository<CommonData> CommonDatas => _CommonDatas ??= new GenericRepository<CommonData>(_context);
		public IGenericRepository<Employee> Employees => _Employees ??= new GenericRepository<Employee>(_context);
		public IGenericRepository<Attendance> Attendances => _Attendances ??= new GenericRepository<Attendance>(_context);
		public IGenericRepository<TestParent> TestParents => _TestParents ??= new GenericRepository<TestParent>(_context);
		public IGenericRepository<TestChild> TestChilds => _TestChilds ??= new GenericRepository<TestChild>(_context);

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

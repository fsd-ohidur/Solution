using System.Linq.Expressions;

namespace Solution.Services.CNFAPI.Repository.IRepository
{
	public interface IGenericRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			List<string> includes = null);
		Task<T> GetAsync(Expression<Func<T, bool>> expression, List<string> includes = null);
		Task CreateAsync(T entity);
		void UpdateAsync(T entity);
		void DeleteAsync(T entity);
		Task<bool> IsExistsAsync(Expression<Func<T, bool>> expression = null);
		Task ExecuteSQLProcedureAsync(string param);
	}
}

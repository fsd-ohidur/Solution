
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Dto;

namespace Solution.Web.HR.Services.IServices
{
	public interface IDepartmentService:IBaseService
	{
		Task<T> GetAllAsync<T>();
		Task<T> GetByIdAsync<T>(Guid id);
		Task<T> CreateAsync<T>(DepartmentDto model);
		Task<T> UpdateAsync<T>(DepartmentDto model);
		Task<T> DeleteAsync<T>(Guid id);
	}
}

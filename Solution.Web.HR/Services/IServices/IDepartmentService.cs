using Solution.Core.Models.HR.Dto;

namespace Solution.Web.HR.Services.IServices
{
	public interface IDepartmentService:IBaseService
	{
		Task<T> GetAllAsync<T>(string ComId);
		Task<T> GetByIdAsync<T>(string ComId, Guid id);
		Task<T> CreateAsync<T>(DepartmentDto model,string UserId);
		Task<T> UpdateAsync<T>(DepartmentDto model, string UserId);
		Task<T> DeleteAsync<T>(string ComId, Guid id);
	}
}

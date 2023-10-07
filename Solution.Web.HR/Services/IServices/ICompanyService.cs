
using Solution.Core.Models.Common.Domain;
using Solution.Core.Models.Common.Dto;

namespace Solution.Web.HR.Services.IServices
{
	public interface ICompanyService:IBaseService
	{
		Task<T> GetAllAsync<T>();
		Task<T> GetByIdAsync<T>(Guid id);
		Task<T> CreateAsync<T>(CompanyDto model, string UserId);
		Task<T> UpdateAsync<T>(CompanyDto model, string UserId);
		Task<T> DeleteAsync<T>(Guid id);
	}
}

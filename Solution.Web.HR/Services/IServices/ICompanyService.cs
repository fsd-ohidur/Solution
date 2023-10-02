
using Solution.Core.Models.Common.Dto;

namespace Solution.Web.HR.Services.IServices
{
	public interface ICompanyService:IBaseService
	{
		Task<T> GetAllAsync<T>();
		Task<T> GetByIdAsync<T>(Guid id);
		Task<T> CreateCompanyAsync<T>(CompanyDto model);
		Task<T> UpdateAsync<T>(CompanyDto model);
		Task<T> DeleteAsync<T>(Guid id);

	}
}

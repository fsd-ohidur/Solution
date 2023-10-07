using Solution.Core.Models.Common.Dto;

namespace Solution.Web.HR.Services.IServices
{
	public interface ICommonDataService : IBaseService
	{
		Task<T> GetAllAsync<T>(string ComId);
		Task<T> GetByIdAsync<T>(string ComId, Guid id);
		Task<T> CreateAsync<T>(CommonDataDto model,string UserId);
		Task<T> UpdateAsync<T>(CommonDataDto model, string UserId);
		Task<T> DeleteAsync<T>(string ComId, Guid id);
	}
}

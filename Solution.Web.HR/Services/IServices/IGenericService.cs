using Solution.Core.Models.Common;
using Solution.Core.Models.Common.Dto;

namespace Solution.Web.HR.Services.IServices
{
	public interface IGenericService<T, TResult> where T: class
	{
		Task<TResult> SendAsync<TResult>(ApiRequest apiRequest);

		Task<TResult> GetAllAsync(string APIBase, string ComId, string UserId, string route);
		Task<TResult> GetCompanyAsync(string APIBase, string ComId, string UserId, string route);
		Task<TResult> GetByIdAsync(string APIBase, string id, string ComId, string UserId, string route);
		Task<TResult> CreateAsync(string APIBase, T model, string ComId, string UserId, string route);
		Task<TResult> UpdateAsync(string APIBase, T model, string ComId, string UserId, string route);
		Task<TResult> DeleteAsync(string APIBase, string id, string ComId, string UserId, string route);
	}
}

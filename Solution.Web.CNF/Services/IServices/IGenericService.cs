using Solution.Core.Models.Common;

namespace Solution.Web.CNF.Services.IServices
{
	public interface IGenericService<T, TResult> where T : class
	{
		Task<TResult> SendAsync<TResult>(ApiRequest apiRequest);

		Task<TResult> GetAllAsync(string ComId, string UserId, string route);
		Task<TResult> GetByIdAsync(string id, string ComId, string UserId, string route);
		Task<TResult> CreateAsync(T model, string ComId, string UserId, string route);
		Task<TResult> UpdateAsync(T model, string ComId, string UserId, string route);
		Task<TResult> DeleteAsync(string id, string ComId, string UserId, string route);
	}
}

using Solution.Web.HR.Models;

namespace Solution.Web.HR.Services.IServices
{
	public interface IBaseService:IDisposable
	{
		ResponseDto responseModel { get; set; }
		Task<T> SendAsync<T>(ApiRequest apiRequest);
	}
}

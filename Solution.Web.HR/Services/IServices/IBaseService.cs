using Solution.Core.Models.Common;
using Solution.Core.Models.Common.Dto;

namespace Solution.Web.HR.Services.IServices
{
	public interface IBaseService
	{
		ResponseDto responseModel { get; set; }
		Task<T> SendAsync<T>(ApiRequest apiRequest);

	}
}

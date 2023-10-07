using Solution.Core;
using Solution.Core.Models.Common;
using Solution.Core.Models.Common.Dto;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Services
{
	public class CommonDataService : BaseService, ICommonDataService
	{
		private readonly IHttpClientFactory _clientFactory;

		public CommonDataService(IHttpClientFactory clientFactory) : base(clientFactory)
		{
			_clientFactory = clientFactory;
		}
		public async Task<T> GetAllAsync<T>(string ComId)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.GET,
				url = SD.HRAPIBase + "/api/commondata",
				AccessToken = "",
				ComId = ComId
			});
		}

		public async Task<T> GetByIdAsync<T>(string ComId, Guid id)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.GET,
				url = SD.HRAPIBase + "/api/commondata/" + id,
				AccessToken = "",
				ComId = ComId
			});
		}
		public async Task<T> CreateAsync<T>(CommonDataDto model, string UserId)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = model,
				url = SD.HRAPIBase + "/api/commondata",
				AccessToken = "",
				UserId = UserId,
				ComId = model.ComId
			});
		}
		public async Task<T> UpdateAsync<T>(CommonDataDto model, string UserId)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.PUT,
				Data = model,
				url = SD.HRAPIBase + "/api/commondata",
				AccessToken = "",
				UserId = UserId,
				ComId = model.ComId
			});
		}
		public async Task<T> DeleteAsync<T>(string ComId, Guid id)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.DELETE,
				url = SD.HRAPIBase + "/api/commondata/" + id,
				AccessToken = "",
				ComId = ComId
			});
		}
	}
}

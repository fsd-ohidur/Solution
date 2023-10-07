
using Solution.Core;
using Solution.Core.Models.Common;
using Solution.Core.Models.HR.Dto;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Services
{
	public class ShiftService : BaseService, IShiftService
	{
		private readonly IHttpClientFactory _clientFactory;

		public ShiftService(IHttpClientFactory clientFactory) : base(clientFactory)
		{
			_clientFactory = clientFactory;
		}
		public async Task<T> GetAllAsync<T>(string ComId)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.GET,
				url = SD.HRAPIBase + "/api/shift",
				AccessToken = "",
				ComId = ComId
			});
		}

		public async Task<T> GetByIdAsync<T>(string ComId, Guid id)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.GET,
				url = SD.HRAPIBase + "/api/shift/" + id,
				AccessToken = "",
				ComId = ComId
			});
		}
		public async Task<T> CreateAsync<T>(ShiftDto model, string UserId)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = model,
				url = SD.HRAPIBase + "/api/shift",
				AccessToken = "",
				UserId = UserId,
				ComId = model.ComId
			});
		}
		public async Task<T> UpdateAsync<T>(ShiftDto model, string UserId)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.PUT,
				Data = model,
				url = SD.HRAPIBase + "/api/shift",
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
				url = SD.HRAPIBase + "/api/shift/" + id,
				AccessToken = "",
				ComId = ComId
			});
		}
	}
}


using Solution.Core;
using Solution.Core.Models.Common;
using Solution.Core.Models.HR.Dto;
using Solution.Web.HR.Services.IServices;
using System.ComponentModel.Design;

namespace Solution.Web.HR.Services
{
	public class DesignationService : BaseService, IDesignationService
	{
		private readonly IHttpClientFactory _clientFactory;

		public DesignationService(IHttpClientFactory clientFactory) : base(clientFactory)
		{
			_clientFactory = clientFactory;
		}
		public async Task<T> GetAllAsync<T>(string ComId)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.GET,
				url = SD.HRAPIBase + "/api/designation",
				AccessToken = "",
				ComId=ComId
			});
		}

		public async Task<T> GetByIdAsync<T>(string ComId, Guid id)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.GET,
				url = SD.HRAPIBase + "/api/designation/" + id,
				AccessToken = "",
				ComId=ComId
			});
		}
		public async Task<T> CreateAsync<T>(DesignationDto model, string UserId)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = model,
				url = SD.HRAPIBase + "/api/designation",
				AccessToken = "",
				UserId= UserId,
				ComId=model.ComId
			});
		}
		public async Task<T> UpdateAsync<T>(DesignationDto model, string UserId)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.PUT,
				Data = model,
				url = SD.HRAPIBase + "/api/designation",
				AccessToken = "",
				UserId= UserId,
				ComId = model.ComId
			});
		}

		public async Task<T> DeleteAsync<T>(string ComId, Guid id)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.DELETE,
				url = SD.HRAPIBase + "/api/designation/" + id,
				AccessToken = "",
				ComId = ComId
			});
		}




	}
}


using Solution.Core;
using Solution.Core.Models.Common;
using Solution.Core.Models.HR.Dto;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Services
{
	public class DesignationService : BaseService, IDesignationService
	{
		private readonly IHttpClientFactory _clientFactory;

		public DesignationService(IHttpClientFactory clientFactory):base(clientFactory)
		{
			_clientFactory = clientFactory;
		}

		public async Task<T> CreateAsync<T>(DesignationDto model)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = model,
				url = SD.HRAPIBase + "/api/designation",
				AccessToken = ""
			}) ;
		}

		public async Task<T> DeleteAsync<T>(Guid id)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.DELETE,
				url = SD.HRAPIBase + "/api/designation/" + id,
				AccessToken = ""
			});
		}

		public async Task<T> GetAllAsync<T>()
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.GET,
				url = SD.HRAPIBase + "/api/designation",
				AccessToken = ""
			});
		}

		public async Task<T> GetByIdAsync<T>(Guid id)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.GET,
				url = SD.HRAPIBase + "/api/designation/" + id,
				AccessToken = ""
			});
		}

		public async Task<T> UpdateAsync<T>(DesignationDto model)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.PUT,
				Data = model,
				url = SD.HRAPIBase + "/api/designation",
				AccessToken = ""
			});
		}
	}
}

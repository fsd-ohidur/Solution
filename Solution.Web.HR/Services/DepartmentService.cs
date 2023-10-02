
using Solution.Core;
using Solution.Core.Models.Common;
using Solution.Core.Models.HR.Dto;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Services
{
	public class DepartmentService : BaseService, IDepartmentService
	{
		private readonly IHttpClientFactory _clientFactory;

		public DepartmentService(IHttpClientFactory clientFactory):base(clientFactory)
		{
			_clientFactory = clientFactory;
		}

		public async Task<T> CreateAsync<T>(DepartmentDto model)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = model,
				url = SD.HRAPIBase + "/api/department",
				AccessToken = ""
			}) ;
		}

		public async Task<T> DeleteAsync<T>(Guid id)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.DELETE,
				url = SD.HRAPIBase + "/api/department/" + id,
				AccessToken = ""
			});
		}

		public async Task<T> GetAllAsync<T>()
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.GET,
				url = SD.HRAPIBase + "/api/department",
				AccessToken = ""
			});
		}

		public async Task<T> GetByIdAsync<T>(Guid id)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.GET,
				url = SD.HRAPIBase + "/api/department/" + id,
				AccessToken = ""
			});
		}

		public async Task<T> UpdateAsync<T>(DepartmentDto model)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.PUT,
				Data = model,
				url = SD.HRAPIBase + "/api/department",
				AccessToken = ""
			});
		}
	}
}


using Solution.Core.Models.Common.Dto;
using Solution.Web.HR.Models;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Services
{
	public class CompanyService : BaseService, ICompanyService
	{
		private readonly IHttpClientFactory _clientFactory;

		public CompanyService(IHttpClientFactory clientFactory):base(clientFactory)
		{
			_clientFactory = clientFactory;
		}

		public async Task<T> CreateCompanyAsync<T>(CompanyDto model)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = model,
				url = SD.HRAPIBase + "/api/company",
				AccessToken = ""
			}) ;
		}

		public async Task<T> DeleteAsync<T>(Guid id)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.DELETE,
				url = SD.HRAPIBase + "/api/company/"+id,
				AccessToken = ""
			});
		}

		public async Task<T> GetAllAsync<T>()
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.GET,
				url = SD.HRAPIBase + "/api/company",
				AccessToken = ""
			});
		}

		public async Task<T> GetByIdAsync<T>(Guid id)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.GET,
				url = SD.HRAPIBase + "/api/company/" + id,
				AccessToken = ""
			});
		}

		public async Task<T> UpdateAsync<T>(CompanyDto model)
		{
			return await this.SendAsync<T>(new ApiRequest()
			{
				ApiType = SD.ApiType.PUT,
				Data = model,
				url = SD.HRAPIBase + "/api/company",
				AccessToken = ""
			});
		}
	}
}

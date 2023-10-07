using Newtonsoft.Json;
using Solution.Core;
using Solution.Core.Models.Common;
using Solution.Core.Models.Common.Dto;
using Solution.Web.HR.Services.IServices;
using System.Text;

namespace Solution.Web.HR.Services
{
	public class BaseService : IBaseService
	{
		public ResponseDto responseModel { get; set; }
		public IHttpClientFactory httpClient { get; set; }
		public BaseService(IHttpClientFactory httpClient)
		{
			this.responseModel = new ResponseDto();
			this.httpClient = httpClient;
		}

		public async Task<T> SendAsync<T>(ApiRequest apiRequest)
		{
			try
			{
				var client = httpClient.CreateClient("HRAPI");
				HttpRequestMessage message = new HttpRequestMessage();
				message.Headers.Add("Accept", "application/json");
				message.Headers.Add("UserId", apiRequest.UserId);
				message.Headers.Add("ComId", apiRequest.ComId);
				message.RequestUri = new Uri(apiRequest.url);
				client.DefaultRequestHeaders.Clear();
				if (apiRequest.Data != null)
				{
					message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
				}
				HttpResponseMessage apiResponse = null;
				switch (apiRequest.ApiType)
				{
					case SD.ApiType.POST:
						message.Method = HttpMethod.Post;
						break;
					case SD.ApiType.PUT:
						message.Method = HttpMethod.Put;
						break;
					case SD.ApiType.DELETE:
						message.Method = HttpMethod.Delete;
						break;
					default:
						message.Method = HttpMethod.Get;
						break;
				}
				apiResponse = await client.SendAsync(message);
				var apiContent = await apiResponse.Content.ReadAsStringAsync();
				var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
				return apiResponseDto;
			}
			catch (Exception ex)
			{
				var dto = new ResponseDto
				{
					DisplayMessage = "Error",
					ErrorMessages = new List<string> { ex.Message },
					IsSuccess = false
				};
				var res = JsonConvert.SerializeObject(dto);
				var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
				return apiResponseDto;
			}
		}


	}
}

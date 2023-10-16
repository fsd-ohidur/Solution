using Newtonsoft.Json;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.Common;
using Solution.Core;
using System.Text;
using Solution.Web.CNF.Services.IServices;

namespace Solution.Web.CNF.Services
{
	public class GenericService<T, TResult> : IGenericService<T, TResult> where T : class
	{
		public IHttpClientFactory _httpClient { get; set; }
		public GenericService(IHttpClientFactory httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<TResult> SendAsync<TResult>(ApiRequest apiRequest)
		{
			try
			{
				var client = _httpClient.CreateClient("HRAPI");
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
				var apiResponseDto = JsonConvert.DeserializeObject<TResult>(apiContent);
				if (apiResponse.IsSuccessStatusCode)
				{
					return JsonConvert.DeserializeObject<TResult>(apiContent);
				}
				return default(TResult); // Return a default value or throw an exception
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
				var apiResponseDto = JsonConvert.DeserializeObject<TResult>(res);
				return apiResponseDto;
			}
		}

		public async Task<TResult> GetAllAsync(string APIBase, string ComId, string UserId, string route)
		{
			var apiRequest = new ApiRequest()
			{
				ApiType = SD.ApiType.GET,
				url = $"{APIBase}/api/{route}",
				AccessToken = "",
				UserId = UserId,
				ComId = ComId
			};
			return await SendAsync<TResult>(apiRequest);
		}

		public async Task<TResult> GetByIdAsync(string APIBase, string id, string ComId, string UserId, string route)
		{
			var apiRequest = new ApiRequest()
			{
				ApiType = SD.ApiType.GET,
				url = $"{APIBase}/api/{route}/" + id,
				AccessToken = "",
				UserId = UserId,
				ComId = ComId
			};
			return await SendAsync<TResult>(apiRequest);
		}
		public async Task<TResult> CreateAsync(string APIBase, T model, string ComId, string UserId, string route)
		{
			var apiRequest = new ApiRequest()
			{
				ApiType = SD.ApiType.POST,
				Data = model,
				url = $"{APIBase}/api/{route}",
				AccessToken = "",
				UserId = UserId,
				ComId = ComId
			};
			return await SendAsync<TResult>(apiRequest);
		}
		public async Task<TResult> UpdateAsync(string APIBase, T model, string ComId, string UserId, string route)
		{
			var apiRequest = new ApiRequest()
			{
				ApiType = SD.ApiType.PUT,
				Data = model,
				url = $"{APIBase}/api/{route}",
				AccessToken = "",
				UserId = UserId,
				ComId = ComId
			};
			return await SendAsync<TResult>(apiRequest);
		}
		public async Task<TResult> DeleteAsync(string APIBase, string id, string ComId, string UserId, string route)
		{
			var apiRequest = new ApiRequest()
			{
				ApiType = SD.ApiType.DELETE,
				url = $"{APIBase}/api/{route}/" + id,
				AccessToken = "",
				UserId = UserId,
				ComId = ComId
			};
			return await SendAsync<TResult>(apiRequest);
		}
	}
}

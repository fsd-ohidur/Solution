using static Solution.Core.SD;

namespace Solution.Core.Models.Common
{
	public class ApiRequest
	{
		public ApiType ApiType { get; set; } = ApiType.GET;
		public string url { get; set; }
		public object Data { get; set; }
		public string AccessToken { get; set; } = "";
		public string UserId { get; set; } = "";
		public string ComId { get; set; } = "";
	}
}

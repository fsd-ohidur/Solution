using Microsoft.AspNetCore.Mvc;
using static Solution.Web.HR.SD;

namespace Solution.Web.HR.Models
{
	public class ApiRequest
	{
		public ApiType ApiType { get; set; } = ApiType.GET;
		public string url { get; set; }
		public object Data { get; set; }
		public string AccessToken { get; set; }
	}
}

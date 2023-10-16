using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solution.Core;
using Solution.Core.Models.Common.Dto;
using Solution.Web.CNF.Models;
using Solution.Web.CNF.Services.IServices;
using System.Diagnostics;

namespace Solution.Web.CNF.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUnitOfService _context;
		private string route = "Company";

		public HomeController(ILogger<HomeController> logger, IUnitOfService context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			//Adding Default User
			//Response.Cookies.Append("UserId", "bb924b67-dd61-4218-9027-77e61ef016c9");
			Response.Cookies.Append("UserId", "Ohid");

			var UserId = Request.Cookies["UserId"];
			var ComId = "";

			List<CompanyDto> list = new();
			var response = await _context.Companies.GetAllAsync(SD.HRAPIBase, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CompanyDto>>(Convert.ToString(response.Result));
				var CompaniesJson = JsonConvert.SerializeObject(list.Select(x => new { x.Id, x.ComName }));

				var cookieOptions = new CookieOptions
				{
					Expires = DateTime.Now.AddDays(7), // Set the desired expiration time
					Path = "/" , // Set the path to the root ("/")
					Secure=true,
					SameSite=SameSiteMode.None
				};
				Response.Cookies.Append("Companies", CompaniesJson, cookieOptions);
				//Response.Cookies.Append("UserId", UserId, cookieOptions);
				//Response.Cookies.Append("ComId", ComId, cookieOptions);
			}
			return View();
		}
		public async Task<IActionResult> SetCompany(string ComId)
		{
			Response.Cookies.Append("ComId", ComId);
			var UserId = Request.Cookies["UserId"];

			CompanyDto model = new();
			var response = await _context.Companies.GetByIdAsync(SD.HRAPIBase, ComId, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				model = JsonConvert.DeserializeObject<CompanyDto>(Convert.ToString(response.Result));

				var cookieOptions = new CookieOptions
				{
					Expires = DateTime.Now.AddDays(7), // Set the desired expiration time
					Path = "/", // Set the path to the root ("/")
					Secure = true,
					SameSite = SameSiteMode.None
				};
				Response.Cookies.Append("ComName", model.ComName, cookieOptions);
			}
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
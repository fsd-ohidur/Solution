using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solution.Core.Models.Common;
using Solution.Core.Models.Common.Dto;
using Solution.Web.HR.Services.IServices;
using System.Diagnostics;

namespace Solution.Web.HR.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICompanyService _context;

		public HomeController(ILogger<HomeController> logger, ICompanyService context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			//Adding Default User
			//Response.Cookies.Append("UserId", "bb924b67-dd61-4218-9027-77e61ef016c9");
			Response.Cookies.Append("UserId", "Ohid");


			List<CompanyDto> list = new();
			var response = await _context.GetAllAsync<ResponseDto>();
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CompanyDto>>(Convert.ToString(response.Result));
				var CompaniesJson = JsonConvert.SerializeObject(list.Select(x => new { x.Id, x.ComName }));

				var cookieOptions = new CookieOptions
				{
					Expires = DateTime.Now.AddDays(7), // Set the desired expiration time
					Path = "/"  // Set the path to the root ("/")
				};
				Response.Cookies.Append("Companies", CompaniesJson, cookieOptions);
			}

			return View();
		}

		public async Task<IActionResult> SetCompany(string ComId)
		{
			Response.Cookies.Append("ComId", ComId);

			var model = await _context.GetByIdAsync<CompanyDto>(Guid.Parse(ComId));
			if (model == null)
			{
				return NotFound();
			}
			Response.Cookies.Append("ComName", model.ComName);
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
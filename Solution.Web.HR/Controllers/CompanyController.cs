
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solution.Core;
using Solution.Core.Models.Common.Dto;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Controllers
{
	public class CompanyController : Controller
	{
		private readonly IUnitOfService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;
		private string route = "Company";

		public CompanyController(IUnitOfService service, IHttpContextAccessor httpContextAccessor)
		{
			_Service = service;
			_httpContextAccessor = httpContextAccessor;
			controllerName = _httpContextAccessor.HttpContext.Request.RouteValues["controller"].ToString();
		}
		public async Task<IActionResult> Index()
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];

			List<CompanyDto> list = new();
			var response = await _Service.Companies.GetAllAsync(SD.HRAPIBase, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CompanyDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		// GET: CompanysController/Details/5
		public async Task<IActionResult> Details(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];

			var model = await _Service.Companies.GetByIdAsync(SD.HRAPIBase, id,ComId, UserId, route);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// GET: CompanysController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CompanysController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CompanyDto model)
		{
			if (ModelState.IsValid)
			{
				var ComId = Request.Cookies["ComId"];
				var UserId = Request.Cookies["UserId"];

				var response = await _Service.Companies.CreateAsync(SD.HRAPIBase, model,ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: CompanysController/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];

			var response = await _Service.Companies.GetByIdAsync(SD.HRAPIBase, id,ComId, UserId, route); ;
			if (response != null && response.IsSuccess)
			{
				CompanyDto model = JsonConvert.DeserializeObject<CompanyDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: CompanysController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(CompanyDto model)
		{
			if (ModelState.IsValid)
			{
				var ComId = Request.Cookies["ComId"];
				var UserId = Request.Cookies["UserId"];

				var response = await _Service.Companies.UpdateAsync(SD.HRAPIBase, model,ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: CompanysController/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];

			var response = await _Service.Companies.GetByIdAsync(SD.HRAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				CompanyDto model = JsonConvert.DeserializeObject<CompanyDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: CompanysController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(CompanyDto model)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];

			var response = await _Service.Companies.DeleteAsync(SD.HRAPIBase, model.Id, ComId, UserId, route);
			if (response.IsSuccess)
			{
				TempData["Success"] = $"{controllerName} deleted successfully.";
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}
	}
}

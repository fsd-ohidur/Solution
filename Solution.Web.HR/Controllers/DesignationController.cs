using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solution.Core;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Dto;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Controllers
{
	public class DesignationController : Controller
	{
		private readonly IUnitOfService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;
		private string route = "Designation";

		public DesignationController(IUnitOfService service, IHttpContextAccessor httpContextAccessor)
		{
			_Service = service;
			_httpContextAccessor = httpContextAccessor;
			controllerName = _httpContextAccessor.HttpContext.Request.RouteValues["controller"].ToString();
		}
		public async Task<IActionResult> Index()
		{
			if (!Request.Cookies.ContainsKey("ComId"))
			{
				return RedirectToAction(nameof(Index), "Home");
			}
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];

			List<DesignationDto> list = new();
			var response = await _Service.Designations.GetAllAsync(SD.HRAPIBase, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<DesignationDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		// GET: DesignationsController/Details/5
		public async Task<IActionResult> Details(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var model = await _Service.Designations.GetByIdAsync(SD.HRAPIBase, id, ComId, UserId, route);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// GET: DesignationsController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: DesignationsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(DesignationDto model)
		{
			if (ModelState.IsValid)
			{
				var ComId = Request.Cookies["ComId"];
				var UserId = Request.Cookies["UserId"];
				model.ComId = ComId;

				var response = await _Service.Designations.CreateAsync(SD.HRAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: DesignationsController/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var response = await _Service.Designations.GetByIdAsync(SD.HRAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				DesignationDto model = JsonConvert.DeserializeObject<DesignationDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: DesignationsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(DesignationDto model)
		{
			if (ModelState.IsValid)
			{
				var ComId = Request.Cookies["ComId"];
				var UserId = Request.Cookies["UserId"];
				model.ComId = ComId;

				var response = await _Service.Designations.UpdateAsync(SD.HRAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: DesignationsController/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var response = await _Service.Designations.GetByIdAsync(SD.HRAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				DesignationDto model = JsonConvert.DeserializeObject<DesignationDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: DesignationsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(DesignationDto model)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var response = await _Service.Designations.DeleteAsync(SD.HRAPIBase, model.Id, ComId, UserId, route);
			if (response.IsSuccess)
			{
				TempData["Success"] = $"{controllerName} deleted successfully.";
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}
	}
}

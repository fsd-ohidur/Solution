using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solution.Core;
using Solution.Core.Models.CNF.Dto;
using Solution.Web.CNF.Services.IServices;

namespace Solution.Web.CNF.Controllers
{
	public class DepotController : Controller
	{
		private readonly IUnitOfService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;
		private string route = "Depot";

		public DepotController(IUnitOfService service, IHttpContextAccessor httpContextAccessor)
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
			//var ComId = Request.Cookies["ComId"];
			//var UserId = Request.Cookies["UserId"];

			//List<DepotDto> list = new();
			//var response = await _Service.Depots.GetAllAsync(SD.CNFAPIBase, ComId, UserId, route);
			//if (response != null && response.IsSuccess)
			//{
			//	list = JsonConvert.DeserializeObject<List<DepotDto>>(Convert.ToString(response.Result));
			//}
			return View();
		}

		// GET: DepotsController/Details/5
		public async Task<IActionResult> Details(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var model = await _Service.Depots.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// GET: DepotsController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: DepotsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(DepotDto model)
		{
			if (ModelState.IsValid)
			{
				string ComId = Request.Cookies["ComId"].ToString();
				string UserId = Request.Cookies["UserId"].ToString();

				model.ComId = ComId;
				var response = await _Service.Depots.CreateAsync(SD.CNFAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: DepotsController/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Depots.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				DepotDto model = JsonConvert.DeserializeObject<DepotDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: DepotsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(DepotDto model)
		{
			if (ModelState.IsValid)
			{
				var ComId = Request.Cookies["ComId"].ToString();
				string UserId = Request.Cookies["UserId"].ToString();

				model.ComId = ComId;
				var response = await _Service.Depots.UpdateAsync(SD.CNFAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: DepotsController/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Depots.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				DepotDto model = JsonConvert.DeserializeObject<DepotDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: DepotsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(DepotDto model)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Depots.DeleteAsync(SD.CNFAPIBase, model.Id, ComId, UserId, route);
			if (response.IsSuccess)
			{
				TempData["Success"] = $"{controllerName} deleted successfully.";
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];

			List<DepotDto> list = new();
			var response = _Service.Depots.GetAllAsync(SD.CNFAPIBase, ComId, UserId, route).Result;
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<DepotDto>>(Convert.ToString(response.Result));
			}
			//return Json(list);
			return Json(new { Success = 1, error = false, data = list });
			//return Json(new { Success = 1, error = false, data = list, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

		}
	}
}

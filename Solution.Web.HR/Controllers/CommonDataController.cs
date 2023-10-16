using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solution.Core;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Dto;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Controllers
{
	public class CommonDataController : Controller
	{
		private readonly IUnitOfService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;
		private string route = "CommonData";


		public CommonDataController(IUnitOfService service, IHttpContextAccessor httpContextAccessor)
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
			List<CommonDataDto> list = new();
			var response = await _Service.CommonDatas.GetAllAsync(SD.HRAPIBase, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CommonDataDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		// GET: CommonDatasController/Details/5
		public async Task<IActionResult> Details(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var model = await _Service.CommonDatas.GetByIdAsync(SD.HRAPIBase, id, ComId, UserId, route);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// GET: CommonDatasController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CommonDatasController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CommonDataDto model)
		{
			if (ModelState.IsValid)
			{
				var ComId = Request.Cookies["ComId"];
				var UserId = Request.Cookies["UserId"];
				model.ComId = Request.Cookies["ComId"].ToString();

				var response = await _Service.CommonDatas.CreateAsync(SD.HRAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: CommonDatasController/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var response = await _Service.CommonDatas.GetByIdAsync(SD.HRAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				CommonDataDto model = JsonConvert.DeserializeObject<CommonDataDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: CommonDatasController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(CommonDataDto model)
		{
			if (ModelState.IsValid)
			{
				var ComId = Request.Cookies["ComId"];
				var UserId = Request.Cookies["UserId"];
				model.ComId = Request.Cookies["ComId"].ToString();

				var response = await _Service.CommonDatas.UpdateAsync(SD.HRAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: CommonDatasController/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var response = await _Service.CommonDatas.GetByIdAsync(SD.HRAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				CommonDataDto model = JsonConvert.DeserializeObject<CommonDataDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: CommonDatasController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(CommonDataDto model)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var response = await _Service.CommonDatas.DeleteAsync(SD.HRAPIBase, model.Id, ComId, UserId, route);
			if (response.IsSuccess)
			{
				TempData["Success"] = $"{controllerName} deleted successfully.";
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}
	}
}

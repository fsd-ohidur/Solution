using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solution.Core;
using Solution.Core.Models.Test.Dto;
using Solution.Web.HR.Services.IServices;
using static Solution.Web.HR.Helper.Helper;

namespace Solution.Web.HR.Controllers
{
	public class TestParent1Controller : Controller
	{
		private readonly IUnitOfService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;
		private string route = "TestParent";

		public TestParent1Controller(IUnitOfService service, IHttpContextAccessor httpContextAccessor)
		{
			_Service = service;
			_httpContextAccessor = httpContextAccessor;
			controllerName = _httpContextAccessor.HttpContext.Request.RouteValues["controller"].ToString();
		}

		public async Task<List<TestParentDto>> GetAllAsync()
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];

			List<TestParentDto> list = new();
			var response = await _Service.TestParents.GetAllAsync(SD.HRAPIBase, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<TestParentDto>>(Convert.ToString(response.Result));
			}
			return list;
		}
		public async Task<IActionResult> Index()
		{
			if (!Request.Cookies.ContainsKey("ComId"))
			{
				return RedirectToAction(nameof(Index), "Home");
			}
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];

			//List<TestParentDto> list = new();
			//var response = await _Service.TestParents.GetAllAsync(ComId, UserId, route);
			//if (response != null && response.IsSuccess)
			//{
			//	list = JsonConvert.DeserializeObject<List<TestParentDto>>(Convert.ToString(response.Result));
			//}
			List<TestParentDto> list = await GetAllAsync();
			return View(list);
		}

		// GET: TestParentsController/Create
		[NoDirectAccess]
		public ActionResult Create()
		{
			return View();
		}

		// POST: TestParentsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TestParentDto model)
		{
			if (ModelState.IsValid)
			{
				string ComId = Request.Cookies["ComId"].ToString();
				string UserId = Request.Cookies["UserId"].ToString();

				model.ComId = ComId;
				var response = await _Service.TestParents.CreateAsync(SD.HRAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: TestParentsController/Create
		// GET: TestParentsController/Edit/5
		[NoDirectAccess]
		public async Task<IActionResult> AddOrEdit(string id)
		{
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			if (string.IsNullOrEmpty(id))
			{
				return View(new TestParentDto());
			}
			else
			{
				var response = await _Service.TestParents.GetByIdAsync(SD.HRAPIBase, id, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TestParentDto model = JsonConvert.DeserializeObject<TestParentDto>(Convert.ToString(response.Result));
					return View(model);
				}
				return NotFound();
			}
		}

		// POST: TestParentsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddOrEdit(string id, TestParentDto model)
		{
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();
			model.ComId = ComId;
			if (ModelState.IsValid)
			{
				if (string.IsNullOrEmpty(id))
				{
					var response = await _Service.TestParents.CreateAsync(SD.HRAPIBase, model, ComId, UserId, route);
					if (response != null && response.IsSuccess)
					{
						TempData["Success"] = $"{controllerName} created successfully.";
						return RedirectToAction(nameof(Index));
					}
				}
				else
				{
					var response = await _Service.TestParents.UpdateAsync(SD.HRAPIBase, model, ComId, UserId, route);
					if (response != null && response.IsSuccess)
					{
						TempData["Success"] = $"{controllerName} updated successfully.";
						return RedirectToAction(nameof(Index));
					}
				}
				return Json(new { isValid = true, html = RenderRazorViewToString(this, "_ViewAll", await GetAllAsync()) });
			}
			return Json(new { isValid = false, html = RenderRazorViewToString(this, "AddOrEdit", model) });

		}

		// GET: TestParentsController/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.TestParents.GetByIdAsync(SD.HRAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				TestParentDto model = JsonConvert.DeserializeObject<TestParentDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: TestParentsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(TestParentDto model)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.TestParents.DeleteAsync(SD.HRAPIBase, model.Id, ComId, UserId, route);
			if (response.IsSuccess)
			{
				TempData["Success"] = $"{controllerName} deleted successfully.";
				return Json(new { html = RenderRazorViewToString(this, "_ViewAll", await GetAllAsync()) });
			}
			return View(model);
		}
	}
}

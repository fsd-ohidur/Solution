using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Dto;
using Solution.Core.Models.Test.Dto;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Controllers
{
	public class TestParentController : Controller
	{
		private readonly IUnitOfService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;
		private string route = "TestParent";

		public TestParentController(IUnitOfService service, IHttpContextAccessor httpContextAccessor)
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

			List<TestParentDto> list = new();
			var response = await _Service.TestParents.GetAllAsync(ComId,UserId, route);
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<TestParentDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		// GET: TestParentsController/Details/5
		public async Task<IActionResult> Details(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var model = await _Service.TestParents.GetByIdAsync(id,ComId,UserId, route);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// GET: TestParentsController/Create
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
				var response = await _Service.TestParents.CreateAsync(model,ComId,UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: TestParentsController/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.TestParents.GetByIdAsync(id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				TestParentDto model = JsonConvert.DeserializeObject<TestParentDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: TestParentsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(TestParentDto model)
		{
			if (ModelState.IsValid)
			{
				var ComId = Request.Cookies["ComId"].ToString();
				string UserId = Request.Cookies["UserId"].ToString();

				model.ComId = ComId;
				var response = await _Service.TestParents.UpdateAsync(model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: TestParentsController/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.TestParents.GetByIdAsync(id, ComId, UserId, route);
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

			var response = await _Service.TestParents.DeleteAsync(model.Id, ComId, UserId, route);
			if (response.IsSuccess)
			{
				TempData["Success"] = $"{controllerName} deleted successfully.";
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}
	}
}

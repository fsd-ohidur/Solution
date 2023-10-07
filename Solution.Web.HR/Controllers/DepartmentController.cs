using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Dto;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IUnitOfService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;
		private string route = "Department";

		public DepartmentController(IUnitOfService service, IHttpContextAccessor httpContextAccessor)
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

			List<DepartmentDto> list = new();
			var response = await _Service.Departments.GetAllAsync(ComId,UserId, route);
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<DepartmentDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		// GET: DepartmentsController/Details/5
		public async Task<IActionResult> Details(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var model = await _Service.Departments.GetByIdAsync(id,ComId,UserId, route);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// GET: DepartmentsController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: DepartmentsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(DepartmentDto model)
		{
			if (ModelState.IsValid)
			{
				string ComId = Request.Cookies["ComId"].ToString();
				string UserId = Request.Cookies["UserId"].ToString();

				model.ComId = ComId;
				var response = await _Service.Departments.CreateAsync(model,ComId,UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: DepartmentsController/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Departments.GetByIdAsync(id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				DepartmentDto model = JsonConvert.DeserializeObject<DepartmentDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: DepartmentsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(DepartmentDto model)
		{
			if (ModelState.IsValid)
			{
				var ComId = Request.Cookies["ComId"].ToString();
				string UserId = Request.Cookies["UserId"].ToString();

				model.ComId = ComId;
				var response = await _Service.Departments.UpdateAsync(model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: DepartmentsController/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Departments.GetByIdAsync(id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				DepartmentDto model = JsonConvert.DeserializeObject<DepartmentDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: DepartmentsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(DepartmentDto model)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Departments.DeleteAsync(model.Id, ComId, UserId, route);
			if (response.IsSuccess)
			{
				TempData["Success"] = $"{controllerName} deleted successfully.";
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}
	}
}

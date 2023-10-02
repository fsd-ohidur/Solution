
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Dto;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IDepartmentService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;


		public DepartmentController(IDepartmentService service, IHttpContextAccessor httpContextAccessor)
		{
			_Service = service;
			_httpContextAccessor = httpContextAccessor;
			controllerName = _httpContextAccessor.HttpContext.Request.RouteValues["controller"].ToString();
		}
		public async Task<IActionResult> Index()
		{
			List<DepartmentDto> list = new();
			var response = await _Service.GetAllAsync<ResponseDto>();
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<DepartmentDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		// GET: DepartmentsController/Details/5
		public async Task<IActionResult> Details(Guid id)
		{
			var model = await _Service.GetByIdAsync<DepartmentDto>(id);
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
				model.ComId = Request.Cookies["ComId"].ToString();

				var response = await _Service.CreateAsync<ResponseDto>(model);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: DepartmentsController/Edit/5
		public async Task<IActionResult> Edit(Guid id)
		{
			var response = await _Service.GetByIdAsync<ResponseDto>(id);
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
				model.ComId = Request.Cookies["ComId"].ToString();

				var response = await _Service.UpdateAsync<ResponseDto>(model);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: DepartmentsController/Delete/5
		public async Task<IActionResult> Delete(Guid id)
		{
			var response = await _Service.GetByIdAsync<ResponseDto>(id);
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
			var response = await _Service.DeleteAsync<ResponseDto>(Guid.Parse(model.Id));
			if(response.IsSuccess)
			{
				TempData["Success"] = $"{controllerName} deleted successfully.";
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}
	}
}

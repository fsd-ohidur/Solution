
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Dto;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Controllers
{
	public class DesignationController : Controller
	{
		private readonly IDesignationService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;


		public DesignationController(IDesignationService service, IHttpContextAccessor httpContextAccessor)
		{
			_Service = service;
			_httpContextAccessor = httpContextAccessor;
			controllerName = _httpContextAccessor.HttpContext.Request.RouteValues["controller"].ToString();
		}
		public async Task<IActionResult> Index()
		{
			List<DesignationDto> list = new();
			var response = await _Service.GetAllAsync<ResponseDto>();
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<DesignationDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		// GET: DesignationsController/Details/5
		public async Task<IActionResult> Details(Guid id)
		{
			var model = await _Service.GetByIdAsync<DesignationDto>(id);
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

		// GET: DesignationsController/Edit/5
		public async Task<IActionResult> Edit(Guid id)
		{
			var response = await _Service.GetByIdAsync<ResponseDto>(id);
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

		// GET: DesignationsController/Delete/5
		public async Task<IActionResult> Delete(Guid id)
		{
			var response = await _Service.GetByIdAsync<ResponseDto>(id);
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

﻿
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solution.Core.Models.Common.Dto;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Controllers
{
    public class CompanyController : Controller
	{
		private readonly ICompanyService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;

		public CompanyController(ICompanyService service, IHttpContextAccessor httpContextAccessor)
		{
			_Service = service;
			_httpContextAccessor = httpContextAccessor;
			controllerName = _httpContextAccessor.HttpContext.Request.RouteValues["controller"].ToString();
		}
		public async Task<IActionResult> Index()
		{
			List<CompanyDto> list = new();
			var response = await _Service.GetAllAsync<ResponseDto>();
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CompanyDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		// GET: CompanysController/Details/5
		public async Task<IActionResult> Details(Guid id)
		{
			var model = await _Service.GetByIdAsync<CompanyDto>(id);
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
				var response = await _Service.CreateAsync<ResponseDto>(model);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: CompanysController/Edit/5
		public async Task<IActionResult> Edit(Guid id)
		{
			var response = await _Service.GetByIdAsync<ResponseDto>(id);
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
				var response = await _Service.UpdateAsync<ResponseDto>(model);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: CompanysController/Delete/5
		public async Task<IActionResult> Delete(Guid id)
		{
			var response = await _Service.GetByIdAsync<ResponseDto>(id);
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

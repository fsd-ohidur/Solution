using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Solution.Core;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Dto;
using Solution.Web.HR.Services.IServices;
using System.Collections.Generic;

namespace Solution.Web.HR.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IUnitOfService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;
		private string route = "Employee";

		public EmployeeController(IUnitOfService service, IHttpContextAccessor httpContextAccessor)
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

			List<EmployeeDto> list = new();
			var response = await _Service.Employees.GetAllAsync(SD.HRAPIBase, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<EmployeeDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		// GET: EmployeesController/Details/5
		public async Task<IActionResult> Details(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var model = await _Service.Employees.GetByIdAsync(SD.HRAPIBase, id, ComId, UserId, route);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// GET: EmployeesController/Create
		public async Task<IActionResult> Create()
		{
			string ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			CompanyDto CompanyData = new();
			List<DepartmentDto> DepartmentList = new();
			List<DesignationDto> DesignationList = new();
			List<ShiftDto> ShiftList = new();
			List<CommonDataDto> CommonDataList = new();

			var response = await _Service.Companies.GetByIdAsync(SD.HRAPIBase, ComId, ComId, UserId, "Company");
			if (response != null && response.IsSuccess)
			{
				CompanyData = JsonConvert.DeserializeObject<CompanyDto>(Convert.ToString(response.Result));
			}
			response = await _Service.Departments.GetAllAsync(SD.HRAPIBase, ComId, UserId, "Department");
			if (response != null && response.IsSuccess)
			{
				DepartmentList = JsonConvert.DeserializeObject<List<DepartmentDto>>(Convert.ToString(response.Result));
			}
			response = await _Service.Designations.GetAllAsync(SD.HRAPIBase, ComId, UserId, "Designation");
			if (response != null && response.IsSuccess)
			{
				DesignationList = JsonConvert.DeserializeObject<List<DesignationDto>>(Convert.ToString(response.Result));
			}
			response = await _Service.Shifts.GetAllAsync(SD.HRAPIBase, ComId, UserId, "Shift");
			if (response != null && response.IsSuccess)
			{
				ShiftList = JsonConvert.DeserializeObject<List<ShiftDto>>(Convert.ToString(response.Result));
			}
			response = await _Service.CommonDatas.GetAllAsync(SD.HRAPIBase, ComId, UserId, "CommonData");
			if (response != null && response.IsSuccess)
			{
				CommonDataList = JsonConvert.DeserializeObject<List<CommonDataDto>>(Convert.ToString(response.Result));
			}

			ViewBag.GrossCalculationRelated = CompanyData;
			ViewBag.Departments = new SelectList(DepartmentList, "Id", "DeptName");
			ViewBag.Designations = new SelectList(DesignationList, "Id", "DesigName");
			ViewBag.Shifts = new SelectList(ShiftList, "Id", "ShiftName");
			ViewBag.Genders = new SelectList(CommonDataList.Where(x => x.CommonType == "GENDER").ToList(), "Id", "CommonName");

			return View();
		}

		// POST: EmployeesController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(EmployeeDto model)
		{
			string ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			if (ModelState.IsValid)
			{
				model.ComId = ComId;
				var response1 = await _Service.Employees.CreateAsync(SD.HRAPIBase, model, ComId, UserId, route);
				if (response1 != null && response1.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}

			CompanyDto CompanyData = new();
			List<DepartmentDto> DepartmentList = new();
			List<DesignationDto> DesignationList = new();
			List<ShiftDto> ShiftList = new();
			List<CommonDataDto> CommonDataList = new();

			var response = await _Service.Companies.GetByIdAsync(SD.HRAPIBase, ComId, ComId, UserId, "Company");
			if (response != null && response.IsSuccess)
			{
				CompanyData = JsonConvert.DeserializeObject<CompanyDto>(Convert.ToString(response.Result));
			}
			response = await _Service.Departments.GetAllAsync(SD.HRAPIBase, ComId, UserId, "Department");
			if (response != null && response.IsSuccess)
			{
				DepartmentList = JsonConvert.DeserializeObject<List<DepartmentDto>>(Convert.ToString(response.Result));
			}
			response = await _Service.Designations.GetAllAsync(SD.HRAPIBase, ComId, UserId, "Designation");
			if (response != null && response.IsSuccess)
			{
				DesignationList = JsonConvert.DeserializeObject<List<DesignationDto>>(Convert.ToString(response.Result));
			}
			response = await _Service.Shifts.GetAllAsync(SD.HRAPIBase, ComId, UserId, "Shift");
			if (response != null && response.IsSuccess)
			{
				ShiftList = JsonConvert.DeserializeObject<List<ShiftDto>>(Convert.ToString(response.Result));
			}
			response = await _Service.CommonDatas.GetAllAsync(SD.HRAPIBase, ComId, UserId, "Shift");
			if (response != null && response.IsSuccess)
			{
				CommonDataList = JsonConvert.DeserializeObject<List<CommonDataDto>>(Convert.ToString(response.Result));
			}

			ViewBag.GrossCalculationRelated = CompanyData;
			ViewBag.Departments = new SelectList(DepartmentList, "Id", "DeptName");
			ViewBag.Designations = new SelectList(DesignationList, "Id", "DesigName");
			ViewBag.Shifts = new SelectList(ShiftList, "Id", "ShiftName");
			ViewBag.Genders = new SelectList(CommonDataList.Where(x => x.CommonType == "Gender"), "Id", "CommonName");
			return View(model);
		}

		// GET: EmployeesController/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Employees.GetByIdAsync(SD.HRAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				EmployeeDto model = JsonConvert.DeserializeObject<EmployeeDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: EmployeesController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EmployeeDto model)
		{
			if (ModelState.IsValid)
			{
				var ComId = Request.Cookies["ComId"].ToString();
				string UserId = Request.Cookies["UserId"].ToString();

				model.ComId = ComId;
				var response = await _Service.Employees.UpdateAsync(SD.HRAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: EmployeesController/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Employees.GetByIdAsync(SD.HRAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				EmployeeDto model = JsonConvert.DeserializeObject<EmployeeDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: EmployeesController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(EmployeeDto model)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Employees.DeleteAsync(SD.HRAPIBase, model.Id, ComId, UserId, route);
			if (response.IsSuccess)
			{
				TempData["Success"] = $"{controllerName} deleted successfully.";
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}
	}
}

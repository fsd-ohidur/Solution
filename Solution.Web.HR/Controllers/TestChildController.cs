using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Dto;
using Solution.Core.Models.Test.Dto;
using Solution.Web.HR.Services.IServices;

namespace Solution.Web.HR.Controllers
{
	public class TestChildController : Controller
	{
		private readonly IUnitOfService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;
		private string route = "TestChild";

		public TestChildController(IUnitOfService service, IHttpContextAccessor httpContextAccessor)
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

			List<TestChildDto> list = new();
			var response = await _Service.TestChilds.GetAllAsync(ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<TestChildDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		// GET: TestChildsController/Details/5
		public async Task<IActionResult> Details(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var model = await _Service.TestChilds.GetByIdAsync(id, ComId, UserId, route);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// GET: TestChildsController/Create
		public async Task<ActionResult> Create()
		{
			ResponseDto response;
			string ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			List<TestParentDto> TestParentList = new();
			response = await _Service.TestParents.GetAllAsync(ComId, UserId, "TestParent");
			if (response != null && response.IsSuccess)
			{
				TestParentList = JsonConvert.DeserializeObject<List<TestParentDto>>(Convert.ToString(response.Result));
			}
			ViewBag.TestParentList = new SelectList(TestParentList, "Id", "ParentName");
			return View();
		}

		// POST: TestChildsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TestChildDto model)
		{
			ResponseDto response;
			string ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			if (ModelState.IsValid)
			{
				model.ComId = ComId;
				response = await _Service.TestChilds.CreateAsync(model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			List<TestParentDto> TestParentList = new();
			response = await _Service.TestParents.GetAllAsync(ComId, UserId, "TestParent");
			if (response != null && response.IsSuccess)
			{
				TestParentList = JsonConvert.DeserializeObject<List<TestParentDto>>(Convert.ToString(response.Result));
			}
			ViewBag.Departments = new SelectList(TestParentList, "Id", "ParentName");

			return View(model);
		}

		// GET: TestChildsController/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.TestChilds.GetByIdAsync(id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				TestChildDto model = JsonConvert.DeserializeObject<TestChildDto>(Convert.ToString(response.Result));

				//--- Dropdown list
				List<TestParentDto> TestParentList = new();
				response = await _Service.TestParents.GetAllAsync(ComId, UserId, "TestParent");
				if (response != null && response.IsSuccess)
				{
					TestParentList = JsonConvert.DeserializeObject<List<TestParentDto>>(Convert.ToString(response.Result));
				}
				ViewBag.TestParentList = new SelectList(TestParentList, "Id", "ParentName");

				return View(model);
			}
			return NotFound();
		}

		// POST: TestChildsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(TestChildDto model)
		{
			ResponseDto response;
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			if (ModelState.IsValid)
			{
				model.ComId = ComId;
				response = await _Service.TestChilds.UpdateAsync(model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			//--- Dropdown list
			List<TestParentDto> TestParentList = new();
			response = await _Service.TestParents.GetAllAsync(ComId, UserId, "TestParent");
			if (response != null && response.IsSuccess)
			{
				TestParentList = JsonConvert.DeserializeObject<List<TestParentDto>>(Convert.ToString(response.Result));
			}
			ViewBag.TestParentList = new SelectList(TestParentList, "Id", "ParentName");
			return View(model);
		}

		// GET: TestChildsController/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			ResponseDto response;
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			response = await _Service.TestChilds.GetByIdAsync(id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				TestChildDto model = JsonConvert.DeserializeObject<TestChildDto>(Convert.ToString(response.Result));

				//--- Dropdown list
				List<TestParentDto> TestParentList = new();
				response = await _Service.TestParents.GetAllAsync(ComId, UserId, "TestParent");
				if (response != null && response.IsSuccess)
				{
					TestParentList = JsonConvert.DeserializeObject<List<TestParentDto>>(Convert.ToString(response.Result));
				}
				ViewBag.TestParentList = new SelectList(TestParentList, "Id", "ParentName");

				return View(model);
			}
			return NotFound();
		}

		// POST: TestChildsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(TestChildDto model)
		{
			ResponseDto response;
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			response = await _Service.TestChilds.DeleteAsync(model.Id, ComId, UserId, route);
			if (response.IsSuccess)
			{
				TempData["Success"] = $"{controllerName} deleted successfully.";
				return RedirectToAction(nameof(Index));
			}
			//--- Dropdown list
			List<TestParentDto> TestParentList = new();
			response = await _Service.TestParents.GetAllAsync(ComId, UserId, "TestParent");
			if (response != null && response.IsSuccess)
			{
				TestParentList = JsonConvert.DeserializeObject<List<TestParentDto>>(Convert.ToString(response.Result));
			}
			ViewBag.TestParentList = new SelectList(TestParentList, "Id", "ParentName");
			return View(model);
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solution.Core.Models.CNF.Dto;
using Solution.Web.CNF.Services.IServices;

namespace Solution.Web.CNF.Controllers
{
	public class ImporterController : Controller
	{
		private readonly IUnitOfService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;
		private string route = "Importer";

		public ImporterController(IUnitOfService service, IHttpContextAccessor httpContextAccessor)
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

			List<ImporterDto> list = new();
			var response = await _Service.Importers.GetAllAsync(ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<ImporterDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}

		// GET: ImportersController/Details/5
		public async Task<IActionResult> Details(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var model = await _Service.Importers.GetByIdAsync(id, ComId, UserId, route);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// GET: ImportersController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ImportersController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ImporterDto model)
		{
			if (ModelState.IsValid)
			{
				string ComId = Request.Cookies["ComId"].ToString();
				string UserId = Request.Cookies["UserId"].ToString();

				model.ComId = ComId;
				var response = await _Service.Importers.CreateAsync(model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: ImportersController/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Importers.GetByIdAsync(id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				ImporterDto model = JsonConvert.DeserializeObject<ImporterDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: ImportersController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(ImporterDto model)
		{
			if (ModelState.IsValid)
			{
				var ComId = Request.Cookies["ComId"].ToString();
				string UserId = Request.Cookies["UserId"].ToString();

				model.ComId = ComId;
				var response = await _Service.Importers.UpdateAsync(model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: ImportersController/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Importers.GetByIdAsync(id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				ImporterDto model = JsonConvert.DeserializeObject<ImporterDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: ImportersController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(ImporterDto model)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Importers.DeleteAsync(model.Id, ComId, UserId, route);
			if (response.IsSuccess)
			{
				TempData["Success"] = $"{controllerName} deleted successfully.";
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}
	}
}

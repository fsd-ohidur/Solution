using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Solution.Core;
using Solution.Core.Models.CNF.Dto;
using Solution.Web.CNF.Services.IServices;

namespace Solution.Web.CNF.Controllers
{
	public class ChargeController : Controller
	{
		private readonly IUnitOfService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;
		private string route = "Charge";
		private string flag = "Export";

		public ChargeController(IUnitOfService service, IHttpContextAccessor httpContextAccessor)
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
			//var ComId = Request.Cookies["ComId"];
			//var UserId = Request.Cookies["UserId"];

			//List<ChargeDto> list = new();
			//var response = await _Service.Charges.GetAllAsync(SD.CNFAPIBase, ComId, UserId, route);
			//if (response != null && response.IsSuccess)
			//{
			//	list = JsonConvert.DeserializeObject<List<ChargeDto>>(Convert.ToString(response.Result)).Where(x => x.Flag == flag).ToList();
			//}
			return View();
		}

		// GET: ChargesController/Details/5
		public async Task<IActionResult> Details(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var model = await _Service.Charges.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// GET: ChargesController/Create
		public ActionResult Create()
		{
			CreateChargeDto model = new CreateChargeDto()
			{
				Rate=0
			};
			return View(model);
		}

		// POST: ChargesController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ChargeDto model)
		{
			if (ModelState.IsValid)
			{
				string ComId = Request.Cookies["ComId"].ToString();
				string UserId = Request.Cookies["UserId"].ToString();

				model.ComId = ComId;
				model.Flag = flag;
				var response = await _Service.Charges.CreateAsync(SD.CNFAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: ChargesController/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Charges.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				ChargeDto model = JsonConvert.DeserializeObject<ChargeDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: ChargesController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(ChargeDto model)
		{
			if (ModelState.IsValid)
			{
				var ComId = Request.Cookies["ComId"].ToString();
				string UserId = Request.Cookies["UserId"].ToString();

				model.Flag = flag;
				model.ComId = ComId;
				var response = await _Service.Charges.UpdateAsync(SD.CNFAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: ChargesController/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Charges.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				ChargeDto model = JsonConvert.DeserializeObject<ChargeDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: ChargesController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(ChargeDto model)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Charges.DeleteAsync(SD.CNFAPIBase, model.Id, ComId, UserId, route);
			if (response.IsSuccess)
			{
				TempData["Success"] = $"{controllerName} deleted successfully.";
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];

			List<ChargeDto> list = new();
			var response = _Service.Charges.GetAllAsync(SD.CNFAPIBase, ComId, UserId, route).Result;
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<ChargeDto>>(Convert.ToString(response.Result)).Where(x => x.Flag == flag).ToList();
			}
			return Json(new { Success = 1, error = false, data = list });
		}
	}
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Solution.Core;
using Solution.Core.Models.CNF.Dto;
using Solution.Core.Models.Common.Dto;
using Solution.Web.CNF.Services.IServices;

namespace Solution.Web.CNF.Controllers
{
	public class BankAccountController : Controller
	{
		private readonly IUnitOfService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;
		private string route = "BankAccount";

		public BankAccountController(IUnitOfService service, IHttpContextAccessor httpContextAccessor)
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
			return View();
		}

		// GET: BankAccountsController/Details/5
		public async Task<IActionResult> Details(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var model = await _Service.BankAccounts.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// GET: BankAccountsController/Create
		public async Task<ActionResult> Create()
		{
			string ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			List<BankDto> BankList = new();
			var response = await _Service.Banks.GetAllAsync(SD.CNFAPIBase, ComId, UserId, "Bank");
			if (response != null && response.IsSuccess)
			{
				BankList = JsonConvert.DeserializeObject<List<BankDto>>(Convert.ToString(response.Result)).ToList();
			}
			ViewBag.BankLists = new SelectList(BankList, "Id", "NameFull");

			return View();
		}

		// POST: BankAccountsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(BankAccountDto model)
		{
			string ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();
			ResponseDto response;

			if (ModelState.IsValid)
			{
				model.ComId = ComId;
				response = await _Service.BankAccounts.CreateAsync(SD.CNFAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			List<BankDto> BankList = new();
			response = await _Service.Banks.GetAllAsync(SD.CNFAPIBase, ComId, UserId, "Bank");
			if (response != null && response.IsSuccess)
			{
				BankList = JsonConvert.DeserializeObject<List<BankDto>>(Convert.ToString(response.Result)).ToList();
			}
			ViewBag.BankLists = new SelectList(BankList, "Id", "NameFull");
			return View(model);
		}

		// GET: BankAccountsController/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.BankAccounts.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				BankAccountDto model = JsonConvert.DeserializeObject<BankAccountDto>(Convert.ToString(response.Result));

				List<BankDto> BankList = new();
				response = await _Service.Banks.GetAllAsync(SD.CNFAPIBase, ComId, UserId, "Bank");
				if (response != null && response.IsSuccess)
				{
					BankList = JsonConvert.DeserializeObject<List<BankDto>>(Convert.ToString(response.Result)).ToList();
				}
				ViewBag.BankLists = new SelectList(BankList, "Id", "NameFull");

				return View(model);
			}
			return NotFound();
		}

		// POST: BankAccountsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(BankAccountDto model)
		{
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();
			ResponseDto response;

			if (ModelState.IsValid)
			{
				model.ComId = ComId;
				response = await _Service.BankAccounts.UpdateAsync(SD.CNFAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			List<BankDto> BankList = new();
			response = await _Service.Banks.GetAllAsync(SD.CNFAPIBase, ComId, UserId, "Bank");
			if (response != null && response.IsSuccess)
			{
				BankList = JsonConvert.DeserializeObject<List<BankDto>>(Convert.ToString(response.Result)).ToList();
			}
			ViewBag.BankLists = new SelectList(BankList, "Id", "NameFull");
			return View(model);
		}

		// GET: BankAccountsController/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.BankAccounts.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				BankAccountDto model = JsonConvert.DeserializeObject<BankAccountDto>(Convert.ToString(response.Result));

				List<BankDto> BankList = new();
				response = await _Service.Banks.GetAllAsync(SD.CNFAPIBase, ComId, UserId, "Bank");
				if (response != null && response.IsSuccess)
				{
					BankList = JsonConvert.DeserializeObject<List<BankDto>>(Convert.ToString(response.Result)).ToList();
				}
				ViewBag.BankLists = new SelectList(BankList, "Id", "NameFull");

				return View(model);
			}
			return NotFound();
		}

		// POST: BankAccountsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(BankAccountDto model)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.BankAccounts.DeleteAsync(SD.CNFAPIBase, model.Id, ComId, UserId, route);
			if (response.IsSuccess)
			{
				TempData["Success"] = $"{controllerName} deleted successfully.";
				return RedirectToAction(nameof(Index));
			}

			List<BankDto> BankList = new();
			response = await _Service.Banks.GetAllAsync(SD.CNFAPIBase, ComId, UserId, "Bank");
			if (response != null && response.IsSuccess)
			{
				BankList = JsonConvert.DeserializeObject<List<BankDto>>(Convert.ToString(response.Result)).ToList();
			}
			ViewBag.BankLists = new SelectList(BankList, "Id", "NameFull");
			return View(model);
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];

			List<BankAccountDto> list = new();
			var response = _Service.BankAccounts.GetAllAsync(SD.CNFAPIBase, ComId, UserId, route).Result;
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<BankAccountDto>>(Convert.ToString(response.Result));
			}
			return Json(new { Success = 1, error = false, data = list });
		}
	}
}

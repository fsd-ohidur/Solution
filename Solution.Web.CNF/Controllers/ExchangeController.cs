using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Solution.Core;
using Solution.Core.Models.CNF.Dto;
using Solution.Core.Models.Common.Dto;
using Solution.Web.CNF.Services.IServices;

namespace Solution.Web.CNF.Controllers
{
	public class ExchangeController : Controller
	{
		private readonly IUnitOfService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;
		private string route = "Exchange";
		private string flag = "Export";

		public ExchangeController(IUnitOfService service, IHttpContextAccessor httpContextAccessor)
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

		// GET: ExchangesController/Details/5
		public async Task<IActionResult> Details(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var model = await _Service.Exchanges.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// GET: ExchangesController/Create
		public async Task<ActionResult> Create()
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];

			List<CommonDataDto> CurrencyList = new();
			var response = await _Service.CommonDatas.GetAllAsync(SD.HRAPIBase, ComId, UserId, "CommonData");
			if (response != null && response.IsSuccess)
			{
				CurrencyList = JsonConvert.DeserializeObject<List<CommonDataDto>>(Convert.ToString(response.Result)).Where(x => x.CommonType == "CURRENCY").ToList();
			}
			ViewBag.FromCurrencyList = new SelectList(CurrencyList, "CommonName", "CommonName");
			ViewBag.ToCurrencyList = new SelectList(CurrencyList, "CommonName", "CommonName");

			CreateExchangeDto model = new CreateExchangeDto()
			{
				dtExchange = DateTime.Now.Date,
				FromCurrency = "USD",
				ToCurrency = "BDT"
			};
			return View(model);
		}

		// POST: ExchangesController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ExchangeDto model)
		{
			ResponseDto response = new();
			string ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();
			if (ModelState.IsValid)
			{
				model.ComId = ComId;
				response = await _Service.Exchanges.CreateAsync(SD.CNFAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			List<CommonDataDto> CurrencyList = new();
			response = await _Service.CommonDatas.GetAllAsync(SD.HRAPIBase, ComId, UserId, "CommonData");
			if (response != null && response.IsSuccess)
			{
				CurrencyList = JsonConvert.DeserializeObject<List<CommonDataDto>>(Convert.ToString(response.Result)).Where(x => x.CommonType == "CURRENCY").ToList();
			}
			ViewBag.FromCurrencyList = new SelectList(CurrencyList, "CommonName", "CommonName");
			ViewBag.ToCurrencyList = new SelectList(CurrencyList, "CommonName", "CommonName");
			return View(model);
		}

		// GET: ExchangesController/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Exchanges.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				ExchangeDto model = JsonConvert.DeserializeObject<ExchangeDto>(Convert.ToString(response.Result));

				List<CommonDataDto> CurrencyList = new();
				response = await _Service.CommonDatas.GetAllAsync(SD.HRAPIBase, ComId, UserId, "CommonData");
				if (response != null && response.IsSuccess)
				{
					CurrencyList = JsonConvert.DeserializeObject<List<CommonDataDto>>(Convert.ToString(response.Result)).Where(x => x.CommonType == "CURRENCY").ToList();
				}
				ViewBag.FromCurrencyList = new SelectList(CurrencyList, "CommonName", "CommonName");
				ViewBag.ToCurrencyList = new SelectList(CurrencyList, "CommonName", "CommonName");
				return View(model);
			}
			return NotFound();
		}

		// POST: ExchangesController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(ExchangeDto model)
		{
			ResponseDto response = new();
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();
			if (ModelState.IsValid)
			{
				model.ComId = ComId;
				response = await _Service.Exchanges.UpdateAsync(SD.CNFAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}

			List<CommonDataDto> CurrencyList = new();
			response = await _Service.CommonDatas.GetAllAsync(SD.HRAPIBase, ComId, UserId, "CommonData");
			if (response != null && response.IsSuccess)
			{
				CurrencyList = JsonConvert.DeserializeObject<List<CommonDataDto>>(Convert.ToString(response.Result)).Where(x => x.CommonType == "CURRENCY").ToList();
			}
			ViewBag.FromCurrencyList = new SelectList(CurrencyList, "CommonName", "CommonName");
			ViewBag.ToCurrencyList = new SelectList(CurrencyList, "CommonName", "CommonName");
			return View(model);
		}

		// GET: ExchangesController/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Exchanges.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				ExchangeDto model = JsonConvert.DeserializeObject<ExchangeDto>(Convert.ToString(response.Result));

				List<CommonDataDto> CurrencyList = new();
				response = await _Service.CommonDatas.GetAllAsync(SD.HRAPIBase, ComId, UserId, "CommonData");
				if (response != null && response.IsSuccess)
				{
					CurrencyList = JsonConvert.DeserializeObject<List<CommonDataDto>>(Convert.ToString(response.Result)).Where(x => x.CommonType == "CURRENCY").ToList();
				}
				ViewBag.FromCurrencyList = new SelectList(CurrencyList, "CommonName", "CommonName");
				ViewBag.ToCurrencyList = new SelectList(CurrencyList, "CommonName", "CommonName");
				return View(model);
			}
			return NotFound();
		}

		// POST: ExchangesController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(ExchangeDto model)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Exchanges.DeleteAsync(SD.CNFAPIBase, model.Id, ComId, UserId, route);
			if (response.IsSuccess)
			{
				TempData["Success"] = $"{controllerName} deleted successfully.";
				return RedirectToAction(nameof(Index));
			}

			List<CommonDataDto> CurrencyList = new();
			response = await _Service.CommonDatas.GetAllAsync(SD.HRAPIBase, ComId, UserId, "CommonData");
			if (response != null && response.IsSuccess)
			{
				CurrencyList = JsonConvert.DeserializeObject<List<CommonDataDto>>(Convert.ToString(response.Result)).Where(x => x.CommonType == "CURRENCY").ToList();
			}
			ViewBag.FromCurrencyList = new SelectList(CurrencyList, "CommonName", "CommonName");
			ViewBag.ToCurrencyList = new SelectList(CurrencyList, "CommonName", "CommonName");
			return View(model);
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];

			List<ExchangeDto> list = new();
			var response = _Service.Exporters.GetAllAsync(SD.CNFAPIBase, ComId, UserId, route).Result;
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<ExchangeDto>>(Convert.ToString(response.Result)).Where(x => x.Flag == flag).ToList();
			}
			return Json(new { Success = 1, error = false, data = list });
		}
	}
}

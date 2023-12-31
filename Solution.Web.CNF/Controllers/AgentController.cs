﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Solution.Core;
using Solution.Core.Models.CNF.Dto;
using Solution.Web.CNF.Services.IServices;
using System.Drawing;

namespace Solution.Web.CNF.Controllers
{
	public class AgentController : Controller
	{
		private readonly IUnitOfService _Service;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private string controllerName;
		private string route = "Agent";

		public AgentController(IUnitOfService service, IHttpContextAccessor httpContextAccessor)
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

		// GET: AgentsController/Details/5
		public async Task<IActionResult> Details(string id)
		{
			var ComId = Request.Cookies["ComId"];
			var UserId = Request.Cookies["UserId"];
			var model = await _Service.Agents.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (model == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// GET: AgentsController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: AgentsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(AgentDto model)
		{
			if (ModelState.IsValid)
			{
				string ComId = Request.Cookies["ComId"].ToString();
				string UserId = Request.Cookies["UserId"].ToString();

				model.ComId = ComId;
				var response = await _Service.Agents.CreateAsync(SD.CNFAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} created successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: AgentsController/Edit/5
		public async Task<IActionResult> Edit(string id)
		{
			var ComId = Request.Cookies["ComId"].ToString();
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Agents.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				AgentDto model = JsonConvert.DeserializeObject<AgentDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: AgentsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(AgentDto model)
		{
			if (ModelState.IsValid)
			{
				var ComId = Request.Cookies["ComId"].ToString();
				string UserId = Request.Cookies["UserId"].ToString();

				model.ComId = ComId;
				var response = await _Service.Agents.UpdateAsync(SD.CNFAPIBase, model, ComId, UserId, route);
				if (response != null && response.IsSuccess)
				{
					TempData["Success"] = $"{controllerName} updated successfully.";
					return RedirectToAction(nameof(Index));
				}
			}
			return View(model);
		}

		// GET: AgentsController/Delete/5
		public async Task<IActionResult> Delete(string id)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Agents.GetByIdAsync(SD.CNFAPIBase, id, ComId, UserId, route);
			if (response != null && response.IsSuccess)
			{
				AgentDto model = JsonConvert.DeserializeObject<AgentDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		// POST: AgentsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(AgentDto model)
		{
			var ComId = Request.Cookies["ComId"];
			string UserId = Request.Cookies["UserId"].ToString();

			var response = await _Service.Agents.DeleteAsync(SD.CNFAPIBase, model.Id, ComId, UserId, route);
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

			List<AgentDto> list = new();
			var response = _Service.Agents.GetAllAsync(SD.CNFAPIBase, ComId, UserId, route).Result;
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<AgentDto>>(Convert.ToString(response.Result));
			}
			//return Json(list);
			return Json(new { Success = 1, error = false, data = list});
			//return Json(new { Success = 1, error = false, data = list, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

		}
	}
}

﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.Test.Domain;
using Solution.Core.Models.Test.Dto;
using Solution.Services.HRAPI.Repository.IRepository;

namespace Solution.Services.HRAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestParentController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<TestParentController> _logger;
		private readonly IMapper _mapper;
		protected ResponseDto _response;

		public TestParentController(IUnitOfWork unitOfWork, ILogger<TestParentController> logger, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_response = new ResponseDto();
			_logger = logger;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<object> GetAsync()
		{
			try
			{
				HttpContext.Request.Headers.TryGetValue("ComId", out var ComId);
				IEnumerable<TestParent> model = await _unitOfWork.TestParents.GetAllAsync(x=>x.ComId==ComId.ToString(), orderBy: x => x.OrderBy(y => y.ParentName));
				_response.Result= _mapper.Map<IEnumerable<TestParentDto>>(model); 	
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
				_logger.LogError(ex,$"Something went wrong in the {nameof(GetAsync)}");
				return StatusCode(500, "Internal server error");
			}
			return Ok(_response);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<object> GetAsync(string id)
		{
			try
			{
				HttpContext.Request.Headers.TryGetValue("ComId", out var ComId);
				var model = await _unitOfWork.TestParents.GetAsync(x=>x.Id==id && x.ComId==ComId.ToString());
				_response.Result = model;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
				_logger.LogError(ex, $"Something went wrong in the {nameof(GetAsync)}");
				return StatusCode(500, "Internal server error");
			}
			return _response;
		}
		[HttpPost]
		public async Task<object> CreateAsync([FromBody] CreateTestParentDto model)
		{
			try
			{
				HttpContext.Request.Headers.TryGetValue("UserId", out var UserId);
				var data = _mapper.Map<CreateTestParentDto, TestParent>(model);
				
				data.CreatedBy = UserId; 
				data.LastModifiedBy = UserId;

				await _unitOfWork.TestParents.CreateAsync(data);
				await _unitOfWork.SaveAsync();
				_response.Result = model;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
				_logger.LogError(ex, $"Something went wrong in the {nameof(CreateAsync)}");
				return StatusCode(500, "Internal server error");
			}
			return _response;
		}

		[HttpPut]
		public async Task<object> UpdateAsync([FromBody] TestParentDto model)
		{
			try
			{
				HttpContext.Request.Headers.TryGetValue("ComId", out var ComId);
				HttpContext.Request.Headers.TryGetValue("UserId", out var UserId);
				var data = _mapper.Map<TestParentDto, TestParent>(model);
				
				data.CreatedBy = UserId;
				data.LastModifiedBy = UserId;
				
				var existingData = await _unitOfWork.TestParents.GetAsync(x => x.Id == model.Id && x.ComId == ComId.ToString());
				if (existingData != null)
				{
					data.CreatedDate = existingData.CreatedDate;
					data.CreatedBy = existingData.CreatedBy;
				}

				_unitOfWork.TestParents.UpdateAsync(data);
				await _unitOfWork.SaveAsync();
				_response.Result = model;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
				_logger.LogError(ex, $"Something went wrong in the {nameof(UpdateAsync)}");
				return StatusCode(500, "Internal server error");
			}
			return _response;
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<object> DeleteAsync(string id)
		{
			try
			{
				HttpContext.Request.Headers.TryGetValue("ComId", out var ComId);
				var model = await _unitOfWork.TestParents.GetAsync(x => x.Id.Equals(id) && x.ComId==ComId.ToString());
				if (model == null)
				{
					_response.Result = false;
				}
				_unitOfWork.TestParents.DeleteAsync(model);
				await _unitOfWork.SaveAsync();
				_response.Result = true;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
				_logger.LogError(ex, $"Something went wrong in the {nameof(DeleteAsync)}");
				return StatusCode(500, "Internal server error");
			}
			return _response;
		}

	}
}

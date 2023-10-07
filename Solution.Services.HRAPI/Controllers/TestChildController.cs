using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.Test.Domain;
using Solution.Core.Models.Test.Dto;
using Solution.Services.HRAPI.Repository.IRepository;

namespace Solution.Services.HRAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestChildController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<TestChildController> _logger;
		private readonly IMapper _mapper;
		protected ResponseDto _response;

		public TestChildController(IUnitOfWork unitOfWork, ILogger<TestChildController> logger, IMapper mapper)
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

				List<string> includes = new List<string>() { "TestParent" };
				IEnumerable<TestChild> model = await _unitOfWork.TestChilds.GetAllAsync(expression: x=>x.ComId==ComId.ToString(),includes: includes, orderBy: x => x.OrderBy(y => y.ChildName));
				_response.Result= _mapper.Map<IEnumerable<TestChildDto>>(model); 	
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
				var model = await _unitOfWork.TestChilds.GetAsync(x=>x.Id==id && x.ComId==ComId.ToString());
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
		public async Task<object> CreateAsync([FromBody] CreateTestChildDto model)
		{
			try
			{
				HttpContext.Request.Headers.TryGetValue("UserId", out var UserId);
				var data = _mapper.Map<CreateTestChildDto, TestChild>(model);
				
				data.CreatedBy = UserId; 
				data.LastModifiedBy = UserId;

				await _unitOfWork.TestChilds.CreateAsync(data);
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
		public async Task<object> UpdateAsync([FromBody] TestChildDto model)
		{
			try
			{
				HttpContext.Request.Headers.TryGetValue("ComId", out var ComId);
				HttpContext.Request.Headers.TryGetValue("UserId", out var UserId);
				var data = _mapper.Map<TestChildDto, TestChild>(model);
				
				data.CreatedBy = UserId;
				data.LastModifiedBy = UserId;
				
				var existingData = await _unitOfWork.TestChilds.GetAsync(x => x.Id == model.Id && x.ComId == ComId.ToString());
				if (existingData != null)
				{
					data.CreatedDate = existingData.CreatedDate;
					data.CreatedBy = existingData.CreatedBy;
				}

				_unitOfWork.TestChilds.UpdateAsync(data);
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
				var model = await _unitOfWork.TestChilds.GetAsync(x => x.Id.Equals(id) && x.ComId==ComId.ToString());
				if (model == null)
				{
					_response.Result = false;
				}
				_unitOfWork.TestChilds.DeleteAsync(model);
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

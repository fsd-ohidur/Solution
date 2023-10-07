using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solution.Core.Models.CNF.Domain;
using Solution.Core.Models.CNF.Dto;
using Solution.Core.Models.Common.Dto;
using Solution.Services.CNFAPI.Repository.IRepository;

namespace Solution.Services.CNFAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChargeController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<ChargeController> _logger;
		private readonly IMapper _mapper;
		protected ResponseDto _response;

		public ChargeController(IUnitOfWork unitOfWork, ILogger<ChargeController> logger, IMapper mapper)
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
				IEnumerable<Charge> model = await _unitOfWork.Charges.GetAllAsync(x => x.ComId == ComId.ToString(), orderBy: x => x.OrderBy(y => y.NameFull));
				_response.Result = _mapper.Map<IEnumerable<ChargeDto>>(model);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
				_logger.LogError(ex, $"Something went wrong in the {nameof(GetAsync)}");
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
				var model = await _unitOfWork.Charges.GetAsync(x => x.Id == id && x.ComId == ComId.ToString());
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
		public async Task<object> CreateAsync([FromBody] CreateChargeDto model)
		{
			try
			{
				HttpContext.Request.Headers.TryGetValue("UserId", out var UserId);
				var data = _mapper.Map<CreateChargeDto, Charge>(model);

				data.CreatedBy = UserId;
				data.LastModifiedBy = UserId;

				await _unitOfWork.Charges.CreateAsync(data);
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
		public async Task<object> UpdateAsync([FromBody] ChargeDto model)
		{
			try
			{
				HttpContext.Request.Headers.TryGetValue("ComId", out var ComId);
				HttpContext.Request.Headers.TryGetValue("UserId", out var UserId);
				var data = _mapper.Map<ChargeDto, Charge>(model);

				data.CreatedBy = UserId;
				data.LastModifiedBy = UserId;

				var existingData = await _unitOfWork.Charges.GetAsync(x => x.Id == model.Id && x.ComId == ComId.ToString());
				if (existingData != null)
				{
					data.CreatedDate = existingData.CreatedDate;
					data.CreatedBy = existingData.CreatedBy;
				}

				_unitOfWork.Charges.UpdateAsync(data);
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
				var model = await _unitOfWork.Charges.GetAsync(x => x.Id.Equals(id) && x.ComId == ComId.ToString());
				if (model == null)
				{
					_response.Result = false;
				}
				_unitOfWork.Charges.DeleteAsync(model);
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

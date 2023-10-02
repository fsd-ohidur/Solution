using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Domain;
using Solution.Core.Models.HR.Dto;
using Solution.Services.HRAPI.Repository.IRepository;

namespace Solution.Services.HRAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class DesignationController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<DesignationController> _logger;
		private readonly IMapper _mapper;
		protected ResponseDto _response;

		public DesignationController(IUnitOfWork unitOfWork, ILogger<DesignationController> logger, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_response = new ResponseDto();
			_logger = logger;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<object> Get()
		{
			try
			{
				IEnumerable<Designation> model = await _unitOfWork.Designations.GetAllAsync();
				_response.Result= _mapper.Map<IEnumerable<DesignationDto>>(model); 	
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
				_logger.LogError(ex,$"Something went wrong in the {nameof(Get)}");
				return StatusCode(500, "Internal server error");
			}
			return Ok(_response);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<object> Get(string id)
		{
			try
			{
				var model = await _unitOfWork.Designations.GetAsync(x=>x.Id==id);
				_response.Result = model;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}
		[HttpPost]
		public async Task<object> CreateAsync([FromBody] CreateDesignationDto model)
		{
			try
			{
				var data = _mapper.Map<CreateDesignationDto, Designation>(model);
				await _unitOfWork.Designations.CreateAsync(data);
				await _unitOfWork.SaveAsync();
				_response.Result = model;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[HttpPut]
		public async Task<object> UpdateAsync([FromBody] DesignationDto model)
		{
			try
			{
				var data = _mapper.Map<DesignationDto, Designation>(model);
				var existingData = await _unitOfWork.Designations.GetAsync(x => x.Id == model.Id);
				if (existingData != null)
				{
					data.CreatedDate = existingData.CreatedDate;
					data.CreatedBy = existingData.CreatedBy;
				}


				_unitOfWork.Designations.UpdateAsync(data);
				await _unitOfWork.SaveAsync();
				_response.Result = model;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<object> DeleteAsync(string id)
		{
			try
			{
				var model = await _unitOfWork.Designations.GetAsync(x => x.Id.Equals(id));
				if (model == null)
				{
					_response.Result = false;
				}
				_unitOfWork.Designations.DeleteAsync(model);
				await _unitOfWork.SaveAsync();
				_response.Result = true;
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}

	}
}

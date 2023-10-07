using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Solution.Core.Models.Common.Domain;
using Solution.Core.Models.Common.Dto;
using Solution.Services.HRAPI.Repository.IRepository;

namespace Solution.Services.HRAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<CompanyController> _logger;
		private readonly IMapper _mapper;
		protected ResponseDto _response;

		public CompanyController(IUnitOfWork unitOfWork, ILogger<CompanyController> logger, IMapper mapper)
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
				IEnumerable<Company> model = await _unitOfWork.Companies.GetAllAsync(orderBy:x=>x.OrderBy(y=>y.ComName));
				_response.Result = _mapper.Map<List<CompanyDto>>(model);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
				_logger.LogError(ex, $"Something went wrong in the {nameof(Get)}");
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
				var model = await _unitOfWork.Companies.GetAsync(x => x.Id == id);
				_response.Result = _mapper.Map<CompanyDto>(model);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.ErrorMessages = new List<string>() { ex.ToString() };
			}
			return _response;
		}
		[HttpPost]
		public async Task<object> CreateAsync([FromBody] CreateCompanyDto model)
		{
			try
			{
				//Getting data from http client header -- UserId
				HttpContext.Request.Headers.TryGetValue("UserId", out var UserId);
				
				var data = _mapper.Map<CreateCompanyDto, Company>(model);

				data.CreatedBy = UserId;
				data.LastModifiedBy = UserId;

				await _unitOfWork.Companies.CreateAsync(data);
				await _unitOfWork.SaveAsync();
				_response.Result = _mapper.Map<Company, CreateCompanyDto>(data);
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
		public async Task<object> UpdateAsync([FromBody] CompanyDto model)
		{
			try
			{
				//Getting data from http client header -- UserId
				HttpContext.Request.Headers.TryGetValue("UserId", out var UserId);

				var data = _mapper.Map<CompanyDto, Company>(model);

				data.CreatedBy = UserId;
				data.LastModifiedBy = UserId;

				var existingData = await _unitOfWork.Companies.GetAsync(x=>x.Id==model.Id);
				if (existingData != null)
				{
					data.CreatedBy = existingData.CreatedBy;
					data.CreatedDate = existingData.CreatedDate;
				}

				_unitOfWork.Companies.UpdateAsync(data);
				await _unitOfWork.SaveAsync();
				_response.Result = _mapper.Map<Company, CompanyDto>(data);
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
				var model = await _unitOfWork.Companies.GetAsync(x => x.Id.Equals(id));
				if (model == null)
				{
					_response.Result = false;
				}
				_unitOfWork.Companies.DeleteAsync(model);
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

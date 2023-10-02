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
		public async Task<object> Get()
		{
			try
			{
				IEnumerable<Company> model = await _unitOfWork.Companies.GetAllAsync();
				_response.Result= _mapper.Map<IEnumerable<CompanyDto>>(model); 	
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
				var model = await _unitOfWork.Companies.Get(x=>x.Id==id);
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
		public async Task<object> CreateAsync([FromBody] CreateCompanyDto model)
		{
			try
			{
				Company data = _mapper.Map<CreateCompanyDto, Company>(model);
				await _unitOfWork.Companies.CreateAsync(data);
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
		public async Task<object> UpdateAsync([FromBody] CompanyDto model)
		{
			try
			{
				Company data = _mapper.Map<CompanyDto, Company>(model);
				_unitOfWork.Companies.UpdateAsync(data);
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
		public async Task<object> DeleteAsynce([FromBody] CompanyDto model)
		{
			try
			{
				Company data = _mapper.Map<CompanyDto, Company>(model);
				_unitOfWork.Companies.DeleteAsync(data);
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

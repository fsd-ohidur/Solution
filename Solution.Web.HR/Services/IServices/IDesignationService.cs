using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Dto;

namespace Solution.Web.HR.Services.IServices
{
	public interface IDesignationService : IGenericService<ResponseDto,DesignationDto>
	{
		Task<T> CreateAsync<T>(DesignationDto model,string UserId);
		Task<T> UpdateAsync<T>(DesignationDto model,string UserId);
	}
}

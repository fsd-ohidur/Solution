using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace Solution.Core.Models.HR.Dto
{

	public class CreateCompanyDto
	{
		[Required]
		[StringLength(50)]
		[DisplayName("Company Name")]
		public string ComName { get; set; }

		[Required]
		[DisplayName("Basic(%)")]
		public int Basic { get; set; }
		[Required]
		[DisplayName("House Rent(%)")]
		public int HRent { get; set; }
		[Required]
		[DisplayName("Medical Allow.(Tk)")]
		public int Medical { get; set; }
		[DisplayName("Inactive?")]
		public bool IsInactive { get; set; } = false;
	}
	public class CompanyDto : CreateCompanyDto
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
	}
}

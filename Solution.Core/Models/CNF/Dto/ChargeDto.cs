using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Solution.Core.Models.Common.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Core.Models.CNF.Dto
{
	public class CreateChargeDto
	{
		[Required]
		[StringLength(50)]
		[DisplayName("Name")]
		public string NameFull { get; set; }
		[Required]
		[DisplayName("Rate")]
		public double Rate { get; set; }
		[Required]
		[DisplayName("Flag")]
		[ValidateNever]
		public string Flag { get; set; } = "Export";
		[StringLength(15)]
		[DisplayName("Department")]
		[ValidateNever]
		public string Department { get; set; } = "Custom";
		[Required]
		[DisplayName("Disabled?")]
		public bool IsDisabled { get; set; } = false;
		[MaxLength(36)]
		public string? ComId { get; set; }
	}
	public class ChargeDto : CreateChargeDto
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
	}
}

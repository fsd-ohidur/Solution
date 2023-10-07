using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Solution.Core.Models.Common.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Core.Models.CNF.Domain
{
	public class Charge : BaseModel
	{
		[Required]
		[StringLength(50)]
		[DisplayName("Name")]
		public string NameFull { get; set; }
		[Required]
		[DisplayName("Rate")]
		public double Rate { get; set; }
		[Required]
		[StringLength(15)]
		[DisplayName("Flag")]
		public string Flag { get; set; } = "Export";
		[Required]
		[StringLength(15)]
		[DisplayName("Department")]
		public string Department { get; set; } = "Custom";
		[Required]
		[DisplayName("Disabled?")]
		public byte IsDisabled { get; set; } = 0;
		[MaxLength(36)]
		public string? ComId { get; set; }
		[ForeignKey("ComId")]
		[ValidateNever]
		public Company Company { get; set; }
	}
}

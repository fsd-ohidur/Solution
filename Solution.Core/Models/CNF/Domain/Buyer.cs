using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Solution.Core.Models.Common.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Core.Models.CNF.Domain
{
	public class Buyer : BaseModel
	{
		[Required]
		[StringLength(50)]
		[DisplayName("Name")]
		public string NameFull { get; set; }
		[Required]
		[StringLength(50)]
		[DisplayName("Code")]
		public string NameShort { get; set; }
		[Required]
		[StringLength(100)]
		[DisplayName("Address")]
		public string Address { get; set; }
		[Required]
		[StringLength(30)]
		[DisplayName("Contact Name")]
		public string ContName { get; set; } = "";
		[Required]
		[StringLength(30)]
		[DisplayName("Contact No")]
		public string ContNo { get; set; } = "";
		[Required]
		[StringLength(50)]
		[DisplayName("Contact Email")]
		public string ContEmail { get; set; } = "";
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

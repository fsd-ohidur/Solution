using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Solution.Core.Models.Common.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Core.Models.CNF.Domain
{
	public class BankAccount : BaseModel
	{
		[Required]
		[StringLength(50)]
		[DisplayName("Account Name")]
		public string AccName { get; set; }
		[Required]
		[StringLength(50)]
		[DisplayName("Account No")]
		public string AccNo { get; set; }
		[MaxLength(36)]
		[DisplayName("Bank Name?")]
		public string? BankId { get; set; }
		[StringLength(100)]
		[DisplayName("Branch Name")]
		public string? BranchName { get; set; } = "";
		[StringLength(30)]
		[DisplayName("Contact Name")]
		public string? ContName { get; set; } = "";
		[StringLength(30)]
		[DisplayName("Contact No")]
		public string? ContNo { get; set; } = "";
		[StringLength(50)]
		[DisplayName("Contact Email")]
		public string? ContEmail { get; set; } = "";
		[Required]
		[DisplayName("Disabled?")]
		public bool IsDisabled { get; set; } = false;
		[MaxLength(36)]
		public string? ComId { get; set; }

		[ForeignKey("BankId")]
		[ValidateNever]
		public Bank Bank { get; set; }
	}
}

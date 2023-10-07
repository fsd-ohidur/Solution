using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Solution.Core.Models.Common.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Solution.Core.Models.CNF.Domain
{
	public class Client : BaseModel
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
		[StringLength(50)]
		[DisplayName("Bill To")]
		public string BillTo { get; set; }
		[Required]
		[StringLength(100)]
		[DisplayName("Address")]
		public string Address { get; set; }
		[Required]
		[StringLength(100)]
		[DisplayName("Contact Name")]
		public string ContName { get; set; } = "";
		[Required]
		[StringLength(100)]
		[DisplayName("Contact No")]
		public string ContNo { get; set; } = "";
		[Required]
		[StringLength(100)]
		[DisplayName("Contact Email")]
		public string ContEmail { get; set; } = "";
		[Required]
		[DisplayName("Disabled?")]
		public byte IsDisabled { get; set; } = 0;
		[StringLength(15)]
		[DisplayName("Flag")]
		[ValidateNever]
		public string Flag { get; set; } = "Export";
		[DisplayName("CountStartFrom")]
		[ValidateNever]
		public long ComCountFrom { get; set; } =0;
		[DisplayName("Commission 300")]
		[ValidateNever]
		public long Com300 { get; set; } = 0;
		[DisplayName("Commission 300 (Min)")]
		[ValidateNever]
		public long Com300Min { get; set; } = 0;
		[DisplayName("Commission 300 (Max)")]
		[ValidateNever]
		public long Com300Max { get; set; } = 0;
		[DisplayName("Commission 301")]
		[ValidateNever]
		public long Com301 { get; set; } = 0;
		[DisplayName("Commission 301 (Min)")]
		[ValidateNever]
		public long Com301Min { get; set; } = 0;
		[DisplayName("Commission 301 (Max)")]
		[ValidateNever]
		public long Com301Max { get; set; } = 0;
		[MaxLength(36)]
		public string? ComId { get; set; }
		[ForeignKey("ComId")]
		[ValidateNever]
		public Company Company { get; set; }
	}
}

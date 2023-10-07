using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Solution.Core.Models.Common.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Core.Models.CNF.Dto
{
	public class CreateImporterDto
    {
		[Required]
		[StringLength(50)]
		[DisplayName("Name")]
		public string NameFull { get; set; }
		[Required]
		[StringLength(50)]
		[DisplayName("Short Name")]
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
		[Required]
		[StringLength(100)]
		[DisplayName("Bill To")]
		public string BillAddTo { get; set; } = "";
		[Required]
		[StringLength(100)]
		[DisplayName("Commission Rate")]
		public double ComRate { get; set; } = 0;
		[MaxLength(36)]
		public string? ComId { get; set; }
		[ForeignKey("ComId")]
		[ValidateNever]
		public Company Company { get; set; }
	}
	public class ImporterDto : CreateImporterDto
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
	}
}

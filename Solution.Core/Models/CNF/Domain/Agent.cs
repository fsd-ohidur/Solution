using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Solution.Core.Models.Common.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Core.Models.CNF.Domain
{
	public class Agent : BaseModel
	{
		[Required]
		[StringLength(50)]
		[DisplayName("Name")]
		public string NameFull { get; set; }
		[Required]
		[StringLength(50)]
		[DisplayName("Short Name")]
		public string NameShort { get; set; }
		[StringLength(100)]
		[DisplayName("Address")]
		public string? Address { get; set; } = "";
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
	}
}

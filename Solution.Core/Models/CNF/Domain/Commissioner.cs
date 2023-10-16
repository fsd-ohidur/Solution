using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Solution.Core.Models.Common.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Core.Models.CNF.Domain
{
	public class Commissioner : BaseModel
	{
		[Required]
		[StringLength(50)]
		[DisplayName("Name")]
		public string NameFull { get; set; }
		[StringLength(100)]
		[DisplayName("Address")]
		public string? Address { get; set; } = "";
		[Required]
		[DisplayName("Disabled?")]
		public bool IsDisabled { get; set; } = false;
		[MaxLength(36)]
		public string? ComId { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using Solution.Core.Models.Common.Domain;

namespace Solution.Core.Models.HR.Dto
{
	public class CreateDesignationDto
	{
		[Required]
		[StringLength(50)]
		[DisplayName("Name")]
		public string DesigName { get; set; }
		[Required]
		[StringLength(50)]
		[DisplayName("Short Name")]
		public string DesigNameShort { get; set; }
		[MaxLength(36)]
		public string? ComId { get; set; }
		[ForeignKey("ComId")]
		[ValidateNever]
		public Company Company { get; set; }
	}
	public class DesignationDto : CreateDesignationDto
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
	}
	
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using Solution.Core.Models.Common.Domain;

namespace Solution.Core.Models.HR.Dto
{
	public class CreateDepartmentDto
	{
		[Required]
		[StringLength(50)]
		[DisplayName("Name")]
		public string DeptName { get; set; }
		[Required]
		[StringLength(15)]
		[DisplayName("Short Name")]
		public string DeptNameShort { get; set; }
		[MaxLength(36)]
		public string? ComId { get; set; }
		[ForeignKey("ComId")]
		[ValidateNever]
		public Company Company { get; set; }
	}
	public class DepartmentDto : CreateDepartmentDto
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
	}

}

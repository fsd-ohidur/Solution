using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Solution.Core.Models.Common.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Core.Models.Test.Dto
{
	public class CreateTestChildDto
	{
		[Required]
		[StringLength(50)]
		[DisplayName("Name")]
		public string ChildName { get; set; }
		[MaxLength(36)]
		public string? TestParentId { get; set; }
		[ForeignKey("TestParentId")]
		[ValidateNever]
		public TestParentDto TestParent { get; set; }
		[MaxLength(36)]
		public string? ComId { get; set; }
		[ForeignKey("ComId")]
		[ValidateNever]
		public Company Company { get; set; }
	}
	public class TestChildDto: CreateTestChildDto
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();

	}
}

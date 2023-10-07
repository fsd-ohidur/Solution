﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Solution.Core.Models.Common.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Core.Models.Test.Domain
{
    public class TestChild : BaseModel
	{
		[Required]
		[StringLength(50)]
		[DisplayName("Name")]
		public string ChildName { get; set; }
        public string TestParentId { get; set; }
        [ForeignKey("TestParentId")]
        public TestParent TestParent { get; set; }
		[MaxLength(36)]
		public string? ComId { get; set; }
		[ForeignKey("ComId")]
		[ValidateNever]
		public Company Company { get; set; }
	}
}

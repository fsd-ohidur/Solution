using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Solution.Core.Models.Common.Domain;

namespace Solution.Core.Models.HR.Domain
{
    public class Department : BaseModel
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
}

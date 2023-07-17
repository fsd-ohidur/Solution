using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Solution.Services.HRAPI.Domain
{
    public class Department : BaseModel
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string DeptName { get; set; }
        [MaxLength(36)]
        public string? ComId { get; set; }
        [ForeignKey("ComId")]
        [ValidateNever]
        public Company Company { get; set; }
    }
}

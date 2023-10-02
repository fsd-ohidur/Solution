using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Solution.Core.Models.Common.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Core.Models.HR.Domain
{
    public class Employee : BaseModel
    {

        [Required]
        [StringLength(50)]
        [DisplayName("Employee Code")]
        public string EmpCode { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string EmpName { get; set; }

        [MaxLength(36)]
        public string? ComId { get; set; }
        [Required]
        public string DeptId { get; set; }
        [Required]
        public string DesigId { get; set; }
        [Required]
        public string GenderId { get; set; }
        [Required]
        public string ShiftId { get; set; }

        [Range(10000, int.MaxValue, ErrorMessage = "The value must be at least 10,000.")]
        [Required]
        public int Gross { get; set; }
        public int? Basic { get; set; } = 0;
        public int? HRent { get; set; } = 0;
        public int? Medical { get; set; } = 0;
        public int? Other { get; set; } = 0;
        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Joining Date")]
        public DateTime dtJoin { get; set; }

        [ForeignKey("ComId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Company Company { get; set; }
        [ForeignKey("DeptId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Department Department { get; set; }
        [ForeignKey("DesigId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Designation Designation { get; set; }
        [ForeignKey("GenderId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public CommonData Gender { get; set; }
        [ForeignKey("ShiftId")]
        [ValidateNever]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Shift Shift { get; set; }
    }
}

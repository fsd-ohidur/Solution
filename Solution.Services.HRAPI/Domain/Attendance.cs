using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Solution.Services.HRAPI.Domain
{
    public class Attendance : BaseModel
    {
        [Required]
        [DisplayName("Date")]
        public DateTime dtDate { get; set; }
        [MaxLength(36)]
        public string? EmpId { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan TimeIn { get; set; } = TimeSpan.Zero;
        [DataType(DataType.Time)]
        public TimeSpan TimeOut { get; set; } = TimeSpan.Zero;
        [DisplayName("Status")]
        public string? AttnStatus { get; set; }

        [ForeignKey("EmpId")]
        [ValidateNever]
        public Employee Employee { get; set; }

        [MaxLength(36)]
        public string? ComId { get; set; }
        [ForeignKey("ComId")]
        [ValidateNever]
        public Company Company { get; set; }
    }
}

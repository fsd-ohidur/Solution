using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Solution.Services.HRAPI.Domain
{
    public class Shift : BaseModel
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string ShiftName { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan TimeIn { get; set; } = TimeSpan.Zero;
        [DataType(DataType.Time)]
        public TimeSpan TimeOut { get; set; } = TimeSpan.Zero;
        [Required]
        [DataType(DataType.Time)]
        public TimeSpan TimeLate { get; set; } = TimeSpan.Zero;
        [MaxLength(36)]
        public string? ComId { get; set; }
        [ForeignKey("ComId")]
        [ValidateNever]
        public Company Company { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Solution.Core.Models.Common.Domain;

namespace Solution.Core.Models.HR.Domain
{
    public class Designation : BaseModel
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string DesigName { get; set; }
        [MaxLength(36)]
        public string? ComId { get; set; }
        [ForeignKey("ComId")]
        [ValidateNever]
        public Company Company { get; set; }
    }
}

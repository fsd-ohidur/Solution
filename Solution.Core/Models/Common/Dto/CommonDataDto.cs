using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Solution.Core.Models.Common.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Core.Models.Common.Dto
{

    public class CreateCommonDataDto
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string CommonName { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Type")]
        public string CommonType { get; set; }
        [MaxLength(36)]
        public string? ComId { get; set; }
        [ForeignKey("ComId")]
        [ValidateNever]
        public Company Company { get; set; }
    }
    public class CommonDataDto : CreateCommonDataDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}

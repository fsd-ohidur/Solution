using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Solution.Core.Models.Common.Domain
{
    public class BaseModel
    {
        [Key]
        [MaxLength(36)]
        [Column(Order = 1)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ValidateNever]
        public DateTime CreatedDate { get; set; }
        [MaxLength(36)]
        [ValidateNever]
        public string CreatedBy { get; set; }
        [ValidateNever]
        public DateTime LastModifiedDate { get; set; }
        [MaxLength(36)]
        [ValidateNever]
        public string LastModifiedBy { get; set; }
    }
}

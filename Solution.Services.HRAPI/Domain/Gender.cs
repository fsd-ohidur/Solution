using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Solution.Services.HRAPI.Domain
{
    public class Gender : BaseModel
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string GenderName { get; set; }
    }
}

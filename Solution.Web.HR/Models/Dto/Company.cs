using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Web.HR.Models
{
    public class CreateCompanyDto
    {
        public string ComName { get; set; }
        public int Basic { get; set; }
        public int HRent { get; set; }
        public int Medical { get; set; }
        public bool IsInactive { get; set; } = false;
    }
	public class CompanyDto:CreateCompanyDto
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
	}
}

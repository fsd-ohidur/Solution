using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Solution.Core.Models.Common.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Core.Models.CNF.Dto
{
	public class CreateExchangeDto
	{
		[Required]
		[DataType(DataType.DateTime)]
		[DisplayName("Date")]
		public DateTime dtExchange { get; set; }
		[Required]
		[StringLength(10)]
		[DisplayName("From Currency")]
		public string FromCurrency { get; set; }
		[Required]
		[StringLength(10)]
		[DisplayName("To Currency")]
		public string ToCurrency { get; set; }
		[Required]
		[DisplayName("Rate")]
		public double Rate { get; set; } = 1;
		[Required]
		[StringLength(15)]
		[DisplayName("Exchange Type")]
		public string Flag { get; set; } = "Export";
		[MaxLength(36)]
		public string? ComId { get; set; }
	}
	public class ExchangeDto : CreateExchangeDto
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
	}
}

using Solution.Core.Models.CNF.Dto;
using Solution.Core.Models.Common.Dto;

namespace Solution.Web.CNF.Services.IServices
{
	public interface IUnitOfService : IDisposable
	{
		IGenericService<CompanyDto, ResponseDto> Companies { get; }
		IGenericService<CommonDataDto, ResponseDto> CommonDatas { get; }
		IGenericService<AgentDto, ResponseDto> Agents { get; }
		IGenericService<BankDto, ResponseDto> Banks { get; }
		IGenericService<BankAccountDto, ResponseDto> BankAccounts { get; }
		IGenericService<BuyerDto, ResponseDto> Buyers { get; }
		IGenericService<ChargeDto, ResponseDto> Charges { get; }
		IGenericService<ClientDto, ResponseDto> Clients { get; }
		IGenericService<CarryingContractorDto, ResponseDto> CarryingContractors { get; }
		IGenericService<DepotDto, ResponseDto> Depots { get; }
		IGenericService<ExchangeDto, ResponseDto> Exchanges { get; }
		IGenericService<ExporterDto, ResponseDto> Exporters { get; }
		IGenericService<ForwarderDto, ResponseDto> Forwarders { get; }
		IGenericService<ImporterDto, ResponseDto> Importers { get; }
		IGenericService<SupplierDto, ResponseDto> Suppliers { get; }
		IGenericService<CommissionerDto, ResponseDto> Commissioners { get; }

	}
}

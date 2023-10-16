using Solution.Core.Models.CNF.Domain;
using Solution.Core.Models.CNF.Dto;
using Solution.Core.Models.Common.Dto;
using Solution.Core.Models.HR.Dto;
using Solution.Core.Models.Test.Dto;
using Solution.Web.CNF.Services.IServices;

namespace Solution.Web.CNF.Services
{
	public class UnitOfService : IUnitOfService
	{
		public IHttpClientFactory _context { get; set; }

		private GenericService<CompanyDto, ResponseDto> _Companies;
		private GenericService<CommonDataDto, ResponseDto> _CommonDatas;
		private GenericService<AgentDto, ResponseDto> _Agents;
		private GenericService<BankDto, ResponseDto> _Banks;
		private GenericService<BankAccountDto, ResponseDto> _BankAccounts;
		private GenericService<BuyerDto, ResponseDto> _Buyers;
		private GenericService<ChargeDto, ResponseDto> _Charges;
		private GenericService<ClientDto, ResponseDto> _Clients;
		private GenericService<CarryingContractorDto, ResponseDto> _CarryingContractors;
		private GenericService<DepotDto, ResponseDto> _Depots;
		private GenericService<ExchangeDto, ResponseDto> _Exchanges;
		private GenericService<ExporterDto, ResponseDto> _Exporters;
		private GenericService<ForwarderDto, ResponseDto> _Forwarders;
		private GenericService<ImporterDto, ResponseDto> _Importers;
		private GenericService<SupplierDto, ResponseDto> _Suppliers;
		private GenericService<CommissionerDto, ResponseDto> _Commissioners;

		public UnitOfService(IHttpClientFactory context)
		{
			_context = context;
		}

		public IGenericService<CompanyDto, ResponseDto> Companies => _Companies ??= new GenericService<CompanyDto, ResponseDto>(_context);
		public IGenericService<CommonDataDto, ResponseDto> CommonDatas => _CommonDatas ??= new GenericService<CommonDataDto, ResponseDto>(_context);
		public IGenericService<AgentDto, ResponseDto> Agents => _Agents ??= new GenericService<AgentDto, ResponseDto>(_context);
		public IGenericService<BankDto, ResponseDto> Banks => _Banks ??= new GenericService<BankDto, ResponseDto>(_context);
		public IGenericService<BankAccountDto, ResponseDto> BankAccounts => _BankAccounts ??= new GenericService<BankAccountDto, ResponseDto>(_context);
		public IGenericService<BuyerDto, ResponseDto> Buyers => _Buyers ??= new GenericService<BuyerDto, ResponseDto>(_context);
		public IGenericService<ChargeDto, ResponseDto> Charges => _Charges ??= new GenericService<ChargeDto, ResponseDto>(_context);
		public IGenericService<ClientDto, ResponseDto> Clients => _Clients ??= new GenericService<ClientDto, ResponseDto>(_context);
		public IGenericService<CarryingContractorDto, ResponseDto> CarryingContractors => _CarryingContractors ??= new GenericService<CarryingContractorDto, ResponseDto>(_context);
		public IGenericService<DepotDto, ResponseDto> Depots => _Depots ??= new GenericService<DepotDto, ResponseDto>(_context);
		public IGenericService<ExchangeDto, ResponseDto> Exchanges => _Exchanges ??= new GenericService<ExchangeDto, ResponseDto>(_context);
		public IGenericService<ExporterDto, ResponseDto> Exporters => _Exporters ??= new GenericService<ExporterDto, ResponseDto>(_context);
		public IGenericService<ForwarderDto, ResponseDto> Forwarders => _Forwarders ??= new GenericService<ForwarderDto, ResponseDto>(_context);
		public IGenericService<ImporterDto, ResponseDto> Importers => _Importers ??= new GenericService<ImporterDto, ResponseDto>(_context);
		public IGenericService<SupplierDto, ResponseDto> Suppliers => _Suppliers ??= new GenericService<SupplierDto, ResponseDto>(_context);
		public IGenericService<CommissionerDto, ResponseDto> Commissioners => _Commissioners ??= new GenericService<CommissionerDto, ResponseDto>(_context);

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}

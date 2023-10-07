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

		private GenericService<BuyerDto, ResponseDto> _Buyers;
		private GenericService<ChargeDto, ResponseDto> _Charges;
		private GenericService<ClientDto, ResponseDto> _Clients;
		private GenericService<DepotDto, ResponseDto> _Depots;
		private GenericService<ExchangeDto, ResponseDto> _Exchanges;
		private GenericService<ExporterDto, ResponseDto> _Exporters;
		private GenericService<ForwarderDto, ResponseDto> _Forwarders;
		private GenericService<ImporterDto, ResponseDto> _Importers;
		private GenericService<SupplierDto, ResponseDto> _Suppliers;

		public UnitOfService(IHttpClientFactory context)
		{
			_context = context;
		}

		public IGenericService<BuyerDto, ResponseDto> Buyers => _Buyers ??= new GenericService<BuyerDto, ResponseDto>(_context);
		public IGenericService<ChargeDto, ResponseDto> Charges => _Charges ??= new GenericService<ChargeDto, ResponseDto>(_context);
		public IGenericService<ClientDto, ResponseDto> Clients => _Clients ??= new GenericService<ClientDto, ResponseDto>(_context);
		public IGenericService<DepotDto, ResponseDto> Depots => _Depots ??= new GenericService<DepotDto, ResponseDto>(_context);
		public IGenericService<ExchangeDto, ResponseDto> Exchanges => _Exchanges ??= new GenericService<ExchangeDto, ResponseDto>(_context);
		public IGenericService<ExporterDto, ResponseDto> Exporters => _Exporters ??= new GenericService<ExporterDto, ResponseDto>(_context);
		public IGenericService<ForwarderDto, ResponseDto> Forwarders => _Forwarders ??= new GenericService<ForwarderDto, ResponseDto>(_context);
		public IGenericService<ImporterDto, ResponseDto> Importers => _Importers ??= new GenericService<ImporterDto, ResponseDto>(_context);
		public IGenericService<SupplierDto, ResponseDto> Suppliers => _Suppliers ??= new GenericService<SupplierDto, ResponseDto>(_context);

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}

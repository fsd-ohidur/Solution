using AutoMapper;
using Solution.Core.Models.CNF.Domain;
using Solution.Core.Models.CNF.Dto;

namespace Solution.Services.CNFAPI.Configurations
{
	public class MappingInitializer : Profile
	{
		public MappingInitializer()
		{
			CreateMap<Buyer, BuyerDto>().ReverseMap();
			CreateMap<Buyer, CreateBuyerDto>().ReverseMap();
			CreateMap<Charge, ChargeDto>().ReverseMap();
			CreateMap<Charge, CreateChargeDto>().ReverseMap();
			CreateMap<Client, ClientDto>().ReverseMap();
			CreateMap<Client, CreateClientDto>().ReverseMap();
			CreateMap<Depot, DepotDto>().ReverseMap();
			CreateMap<Depot, CreateDepotDto>().ReverseMap();
			CreateMap<Exchange, ExchangeDto>().ReverseMap();
			CreateMap<Exchange, CreateExchangeDto>().ReverseMap();
			CreateMap<Exporter, ExporterDto>().ReverseMap();
			CreateMap<Exporter, CreateExporterDto>().ReverseMap();
			CreateMap<Forwarder, ForwarderDto>().ReverseMap();
			CreateMap<Forwarder, CreateForwarderDto>().ReverseMap();
			CreateMap<Importer, ImporterDto>().ReverseMap();
			CreateMap<Importer, CreateImporterDto>().ReverseMap();
			CreateMap<Supplier, SupplierDto>().ReverseMap();
			CreateMap<Supplier, CreateSupplierDto>().ReverseMap();

			CreateMap<Agent, AgentDto>().ReverseMap();
			CreateMap<Agent, CreateAgentDto>().ReverseMap();
			CreateMap<Bank, BankDto>().ReverseMap();
			CreateMap<Bank, CreateBankDto>().ReverseMap();
			CreateMap<BankAccount, BankAccountDto>().ReverseMap();
			CreateMap<BankAccount, CreateBankAccountDto>().ReverseMap();
			CreateMap<Commissioner, CommissionerDto>().ReverseMap();
			CreateMap<Commissioner, CreateCommissionerDto>().ReverseMap();
			CreateMap<CarryingContractor, CarryingContractorDto>().ReverseMap();
			CreateMap<CarryingContractor, CreateCarryingContractorDto>().ReverseMap();
		}
	}
}

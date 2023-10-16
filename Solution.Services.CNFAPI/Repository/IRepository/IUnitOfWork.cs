using Solution.Core.Models.CNF.Domain;

namespace Solution.Services.CNFAPI.Repository.IRepository
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<Agent> Agents { get; }
		IGenericRepository<Buyer> Buyers { get; }
		IGenericRepository<Bank> Banks { get; }
		IGenericRepository<BankAccount> BankAccounts { get; }
		IGenericRepository<Charge> Charges { get; }
		IGenericRepository<Client> Clients { get; }
		IGenericRepository<CarryingContractor> CarryingContractors { get; }
		IGenericRepository<Depot> Depots { get; }
		IGenericRepository<Exchange> Exchanges { get; }
		IGenericRepository<Exporter> Exporters { get; }
		IGenericRepository<Forwarder> Forwarders { get; }
		IGenericRepository<Importer> Importers { get; }
		IGenericRepository<Supplier> Suppliers { get; }
		IGenericRepository<Commissioner> Commissioners { get; }

		Task SaveAsync();
	}
}

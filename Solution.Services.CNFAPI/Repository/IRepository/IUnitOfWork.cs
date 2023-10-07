using Solution.Core.Models.CNF.Domain;

namespace Solution.Services.CNFAPI.Repository.IRepository
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<Buyer> Buyers { get; }
		IGenericRepository<Charge> Charges { get; }
		IGenericRepository<Client> Clients { get; }
		IGenericRepository<Depot> Depots { get; }
		IGenericRepository<Exchange> Exchanges { get; }
		IGenericRepository<Exporter> Exporters { get; }
		IGenericRepository<Forwarder> Forwarders { get; }
		IGenericRepository<Importer> Importers { get; }
		IGenericRepository<Supplier> Suppliers { get; }

		Task SaveAsync();
	}
}

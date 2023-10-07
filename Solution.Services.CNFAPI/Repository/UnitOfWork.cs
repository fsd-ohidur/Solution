using Solution.Core.Models.CNF.Domain;
using Solution.Services.CNFAPI.Data;
using Solution.Services.CNFAPI.Repository.IRepository;

namespace Solution.Services.CNFAPI.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _context;

		private GenericRepository<Buyer> _Buyers;
		private GenericRepository<Charge> _Charges;
		private GenericRepository<Client> _Clients;
		private GenericRepository<Depot> _Depots;
		private GenericRepository<Exchange> _Exchanges;
		private GenericRepository<Exporter> _Exporters;
		private GenericRepository<Forwarder> _Forwarders;
		private GenericRepository<Importer> _Importers;
		private GenericRepository<Supplier> _Suppliers;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
		}
		public IGenericRepository<Buyer> Buyers => _Buyers ??= new GenericRepository<Buyer>(_context);
		public IGenericRepository<Charge> Charges => _Charges ??= new GenericRepository<Charge>(_context);
		public IGenericRepository<Client> Clients => _Clients ??= new GenericRepository<Client>(_context);
		public IGenericRepository<Depot> Depots => _Depots ??= new GenericRepository<Depot>(_context);
		public IGenericRepository<Exchange> Exchanges => _Exchanges ??= new GenericRepository<Exchange>(_context);
		public IGenericRepository<Exporter> Exporters => _Exporters ??= new GenericRepository<Exporter>(_context);
		public IGenericRepository<Forwarder> Forwarders => _Forwarders ??= new GenericRepository<Forwarder>(_context);
		public IGenericRepository<Importer> Importers => _Importers ??= new GenericRepository<Importer>(_context);
		public IGenericRepository<Supplier> Suppliers => _Suppliers ??= new GenericRepository<Supplier>(_context);

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		private void Dispose(bool dispose)
		{
			if (dispose)
			{
				_context.Dispose();
			}
		}
		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}
	}
}

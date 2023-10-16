using Microsoft.EntityFrameworkCore;
using Solution.Core.Models.CNF.Domain;
using Solution.Core.Models.Common.Domain;

namespace Solution.Services.CNFAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public DbSet<Agent> Agents { get; set; }
		public DbSet<Bank> Banks { get; set; }
		public DbSet<BankAccount> BankAccounts { get; set; }
		public DbSet<Buyer> Buyers { get; set; }
		public DbSet<Charge> Charges { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Commissioner> Commissioners { get; set; }
		public DbSet<CarryingContractor> CarryingContractors { get; set; }
		public DbSet<Depot> Depots { get; set; }
		public DbSet<Exchange> Exchanges { get; set; }
		public DbSet<Exporter> Exporters { get; set; }
		public DbSet<Forwarder> Forwarders { get; set; }
		public DbSet<Importer> Importers { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }

		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
		{
			HttpContext httpContext = _httpContextAccessor.HttpContext;
			foreach (var entry in ChangeTracker.Entries<BaseModel>())
			{
				entry.Entity.LastModifiedDate = DateTime.Now;
				//entry.Entity.LastModifiedBy = "Ohid";// httpContext.Request.Cookies["UserId"].ToString();

				if (entry.State == EntityState.Added)
				{
					{
						entry.Entity.CreatedDate = DateTime.Now;
						//entry.Entity.CreatedBy = "Ohid";// httpContext.Request.Cookies["UserId"].ToString();
					}
				}
			}
			return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}
	}
}

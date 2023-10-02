using Microsoft.EntityFrameworkCore;
using Solution.Core.Models.Common.Domain;
using Solution.Core.Models.HR.Domain;

namespace Solution.Services.HRAPI.Data
{
    public class ApplicationDbContext : DbContext
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
		{
			_httpContextAccessor = httpContextAccessor;
		}
		public DbSet<Company> Companies { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Designation> Designations { get; set; }
		public DbSet<CommonData> CommonDatas { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Shift> Shifts { get; set; }
		public DbSet<Attendance> Attendances { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Company>()
				.HasIndex(e => new { e.ComName })
				.IsUnique();

			modelBuilder.Entity<Department>()
				.HasIndex(e => new { e.ComId, e.DeptName })
				.IsUnique();

			modelBuilder.Entity<Department>()
			   .HasOne(e => e.Company)
			   .WithMany()
			   .HasForeignKey(e => e.ComId)
			   .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Designation>()
				.HasIndex(e => new { e.ComId, e.DesigName })
				.IsUnique();

			modelBuilder.Entity<Designation>()
			   .HasOne(e => e.Company)
			   .WithMany()
			   .HasForeignKey(e => e.ComId)
			   .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Shift>()
				.HasIndex(e => new { e.ComId, e.ShiftName })
				.IsUnique();

			modelBuilder.Entity<Shift>()
			   .HasOne(e => e.Company)
			   .WithMany()
			   .HasForeignKey(e => e.ComId)
			   .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Employee>()
			   .HasOne(e => e.Gender)
			   .WithMany()
			   .HasForeignKey(e => e.GenderId)
			   .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Attendance>()
			   .HasOne(e => e.Company)
			   .WithMany()
			   .HasForeignKey(e => e.ComId)
			   .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Attendance>()
			   .HasOne(e => e.Employee)
			   .WithMany()
			   .HasForeignKey(e => e.EmpId)
			   .OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(modelBuilder);
		}

		public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
		{
			HttpContext httpContext = _httpContextAccessor.HttpContext;
			foreach (var entry in ChangeTracker.Entries<BaseModel>())
			{
				entry.Entity.LastModifiedDate = DateTime.Now;
				entry.Entity.LastModifiedBy = "Ohid";// httpContext.Request.Cookies["UserId"].ToString();

				if (entry.State == EntityState.Added)
				{
					{
						entry.Entity.CreatedDate = DateTime.Now;
						entry.Entity.CreatedBy = "Ohid";// httpContext.Request.Cookies["UserId"].ToString();
					}
				}
			}
			return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
		}
	}
}
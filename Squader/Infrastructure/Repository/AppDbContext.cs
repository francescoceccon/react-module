using Infrastructure.Repository.Lead;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repository
{
	public class AppDbContext : DbContext
	{
		public DbSet<Domain.Models.Lead> Leads { get; set; }
		private readonly IConfiguration _configuration;

		public AppDbContext() { }

		public AppDbContext(DbContextOptions<AppDbContext> options,IConfiguration configuration) : base(options) 
		{
			_configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured) return;

			var connectionString = _configuration.GetConnectionString("DefaultConnection");

			optionsBuilder.UseSqlServer(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new LeadConfiguration());
			base.OnModelCreating(modelBuilder);
		}
	}
}

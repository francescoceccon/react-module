using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repository.Seeder
{
	public static class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using var context = serviceProvider.GetRequiredService<AppDbContext>();

			if (context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}

			if (context.Leads.Any())
				return; 

			context.Leads.AddRange(
				Domain.Models.Lead.Create("João", "Silva", DateTime.UtcNow, "São Paulo", "Eletricista", 101, "Instalar fiação", 300, (int)LeadStatus.Invited, "11999990000", "joao@example.com"),
				Domain.Models.Lead.Create("Maria", "Souza", DateTime.UtcNow, "Campinas", "Pintura", 102, "Pintar apartamento", 500, (int)LeadStatus.Invited, "11988880000", "maria@example.com"),
				Domain.Models.Lead.Create("Fernando", "Gil", DateTime.UtcNow, "Rio de Janeiro", "Limpeza", 103, "Limpeza pós-obra", 250, (int)LeadStatus.Invited, "11988887890", "fernandogil@example.com"),
				Domain.Models.Lead.Create("Alex", "Niteroi", DateTime.UtcNow, "Curitiba", "Reforma", 104, "Reforma banheiro", 800, (int)LeadStatus.Invited, "41912345678", "ana@example.com"),
				Domain.Models.Lead.Create("Lucas", "Ferreira", DateTime.UtcNow, "Belo Horizonte", "Jardinagem", 105, "Cuidar do jardim", 150, (int)LeadStatus.Invited, "31998765432", "lucas@example.com")
			);

			context.SaveChanges();
		}
	}
}

using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class DependencyInjection
	{
		public static void AddRepositories(this IServiceCollection services,IConfiguration configuration)
		{
            Console.WriteLine(configuration.GetConnectionString("DefaultConnection")!);

            services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")!));
		}
	}
}

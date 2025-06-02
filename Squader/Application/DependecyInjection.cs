using Application.Services.Email;
using Domain.Interfaces.Repository;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
	public static class DependecyInjection
	{
		public static void AddDependencies(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddRepositories(configuration);

			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			services.AddScoped<ILeadRepository, LeadRepository>();
			services.AddScoped<IEmailService, EmailService>();
		}
	}
}

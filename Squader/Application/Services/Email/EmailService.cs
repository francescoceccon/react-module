using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Email
{
	internal class EmailService : IEmailService
	{
		public Task SendEmailAsync(Lead lead)
		{
			Console.WriteLine($"Email sent to vendas@test.com for lead {lead.Id} - {lead.FirstName}\n");
			return Task.CompletedTask;
        }
	}
}

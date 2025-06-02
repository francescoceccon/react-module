using Domain.Models;

namespace Application.Services.Email
{
	public interface IEmailService
	{
		Task SendEmailAsync(Lead lead);
	}
}

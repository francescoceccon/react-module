using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
	public interface ILeadRepository
	{
		Task<List<Lead>> GetInvitedAsync();
		Task<List<Lead>> GetAcceptedAsync();
		Task<Lead?> GetByIdAsync(Guid id);
		Task UpdateAsync(Lead lead);
	}
}

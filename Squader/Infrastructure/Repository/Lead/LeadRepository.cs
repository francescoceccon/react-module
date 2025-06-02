using Domain.Enums;
using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

public class LeadRepository : ILeadRepository
{
	private readonly AppDbContext _context;
	public LeadRepository(AppDbContext context) => _context = context;

	public async Task<List<Lead>> GetInvitedAsync()
	{
		return await _context.Leads.Where(l => l.Status == (int)LeadStatus.Invited).ToListAsync();
	}

	public async Task<List<Lead>> GetAcceptedAsync()
	{
		return await _context.Leads.Where(l => l.Status == (int)LeadStatus.Accepted).ToListAsync();
	}

	public async Task<Lead?> GetByIdAsync(Guid id)
	{
		return await _context.Leads.FindAsync(id);
	}

	public async Task UpdateAsync(Lead lead)
	{
		_context.Leads.Update(lead);
		await _context.SaveChangesAsync();
	}
}
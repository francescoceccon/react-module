using Domain.Enums;
using Domain.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DomainActions.Lead.Commands.Decline
{
    public sealed class DeclineLeadCommandHandler : IRequestHandler<DeclineLeadCommand, bool>
    {
        private readonly ILeadRepository _repo;
        public DeclineLeadCommandHandler(ILeadRepository repo) => _repo = repo;

        public async Task<bool> Handle(DeclineLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _repo.GetByIdAsync(request.LeadId);
            if (lead == null || lead.Status != (int)LeadStatus.Invited) 
                return false;

            lead.Decline();

            await _repo.UpdateAsync(lead);
            return true;
        }
    }
}

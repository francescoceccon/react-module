using Application.Services.Email;
using Domain.Enums;
using Domain.Interfaces.Repository;
using MediatR;

namespace Application.DomainActions.Lead.Commands.Accept
{
    public sealed class AcceptLeadCommandHandler : IRequestHandler<AcceptLeadCommand, bool>
    {
        private readonly ILeadRepository _repo;
        private readonly IEmailService _email;

        public AcceptLeadCommandHandler(ILeadRepository repo, IEmailService email)
        {
            _repo = repo;
            _email = email;
        }

        public async Task<bool> Handle(AcceptLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _repo.GetByIdAsync(request.LeadId);

            if (lead == null || lead.Status != (int)LeadStatus.Invited)
                return false;

            lead.Accept();

            await Task.WhenAll(
                _repo.UpdateAsync(lead),
                _email.SendEmailAsync(lead));

            return true;
        }
    }
}

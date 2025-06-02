using Domain.Enums;
using Domain.Interfaces.Repository;
using MediatR;

namespace Application.DomainActions.Lead.Querys.Invited
{
	internal sealed class InvitedLeadQueryHandler : IRequestHandler<InvitedLeadQuery, IEnumerable<InvitedResponse>>
	{
		private readonly ILeadRepository _repository;

		public InvitedLeadQueryHandler(ILeadRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<InvitedResponse>> Handle(InvitedLeadQuery request, CancellationToken cancellationToken)
		{
			if (request.Status != (int)LeadStatus.Invited)
				return Enumerable.Empty<InvitedResponse>();

			var inviteds = await _repository.GetInvitedAsync();

			return InvitedResponse.Map(inviteds);
		}
	}
}

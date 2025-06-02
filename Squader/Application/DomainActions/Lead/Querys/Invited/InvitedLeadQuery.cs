using Domain.Enums;
using MediatR;

namespace Application.DomainActions.Lead.Querys.Invited
{
	public sealed record InvitedLeadQuery(int Status = (int)LeadStatus.Invited) : IRequest<IEnumerable<InvitedResponse>>;
}

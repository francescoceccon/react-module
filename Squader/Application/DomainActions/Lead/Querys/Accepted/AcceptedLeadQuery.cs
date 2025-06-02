using Domain.Enums;
using MediatR;

namespace Application.DomainActions.Lead.Querys.Accepted
{
	public sealed record AcceptedLeadQuery(int Status = (int)LeadStatus.Accepted) : IRequest<IEnumerable<Domain.Models.Lead>>;
}

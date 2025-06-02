using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DomainActions.Lead.Commands.Decline
{
    public sealed record DeclineLeadCommand(Guid LeadId) : IRequest<bool>;
}

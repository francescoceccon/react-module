using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DomainActions.Lead.Commands.Accept
{
    public sealed record AcceptLeadCommand(Guid LeadId) : IRequest<bool>;
}

using Domain.Enums;
using Domain.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DomainActions.Lead.Querys.Accepted
{
	internal sealed class AcceptedLeadQueryHandler : IRequestHandler<AcceptedLeadQuery, IEnumerable<Domain.Models.Lead>>
	{
		private readonly ILeadRepository _repository;

		public AcceptedLeadQueryHandler(ILeadRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Domain.Models.Lead>> Handle(AcceptedLeadQuery request, CancellationToken cancellationToken)
		{
			if (request.Status != (int)LeadStatus.Accepted)
				return Enumerable.Empty<Domain.Models.Lead>();

			return await _repository.GetAcceptedAsync();
		}
	}
}

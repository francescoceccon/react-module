namespace Application.DomainActions.Lead.Querys.Invited
{
	public sealed record InvitedResponse
	{
		public Guid Id { get; private set; }
		public string FirstName { get; private set; }
		public string? LastName { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public string Suburb { get; private set; }
		public string Category { get; private set; }
		public int JobId { get; private set; }
		public string Description { get; private set; }
		public decimal Price { get; private set; }
		public int Status { get; private set; }

		internal static IEnumerable<InvitedResponse> Map(List<Domain.Models.Lead> leads)
		{
			return leads.Select(l => new InvitedResponse
			{
				Id = l.Id,
				FirstName = l.FirstName,
				LastName = l.LastName,
				CreatedAt = l.CreatedAt,
				Suburb = l.Suburb,
				Category = l.Category,
				JobId = l.JobId,
				Description = l.Description,
				Price = l.Price,
				Status = l.Status
			});
		}
	}
}

using Domain.Enums;
using System.Runtime.CompilerServices;

namespace Domain.Models
{
	public class Lead
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
		public string? Phone { get; private set; }
		public string? Email { get; private set; }

        private Lead(){	}

		public static Lead Create( 
			string firstName, 
			string? lastName, 
			DateTime createdAt, 
			string suburb,
			string category, 
			int jobId, 
			string description, 
			decimal price, 
			int status, 
			string? phone,
			string? email)
		{
			return new Lead
			{
				Id = Guid.NewGuid(),
				FirstName = firstName,
				LastName = lastName,
				CreatedAt = createdAt,
				Suburb = suburb,
				Category = category,
				JobId = jobId,
				Description = description,
				Price = price,
				Status = status,
				Phone = phone,
				Email = email
			};
		}

		public void Accept()
		{
			if (Price > 500)
				Price *= 0.9m;

			Status = (int)LeadStatus.Accepted;
		}

		public void Decline()
		{
			Status = (int)LeadStatus.Declined;
		}
	}
}

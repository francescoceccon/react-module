using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace Infrastructure.Repository.Lead
{
	internal class LeadConfiguration : IEntityTypeConfiguration<Domain.Models.Lead>
	{
		public void Configure(EntityTypeBuilder<Domain.Models.Lead> builder)
		{
			builder.ToTable("Leads");

			builder.HasKey(l => l.Id);

			builder.Property(l => l.FirstName).IsRequired().HasMaxLength(100);
			builder.Property(l => l.LastName).HasMaxLength(100);
			builder.Property(l => l.CreatedAt).IsRequired();
			builder.Property(l => l.Suburb).IsRequired().HasMaxLength(100);
			builder.Property(l => l.Category).IsRequired().HasMaxLength(100);
			builder.Property(l => l.Description).IsRequired().HasMaxLength(500);
			builder.Property(l => l.Price).IsRequired().HasColumnType("decimal(18,2)");
			builder.Property(l => l.Status).IsRequired();
			builder.Property(l => l.Phone).HasMaxLength(20);
			builder.Property(l => l.Email).HasMaxLength(100);
		}
	}
}

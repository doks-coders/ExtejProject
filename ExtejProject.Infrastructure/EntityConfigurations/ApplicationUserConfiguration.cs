using ExtejProject.SharedModels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExtejProject.Infrastructure.EntityConfigurations
{
	public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder.HasMany(u => u.Transactions).WithOne(u => u.User)
				.HasForeignKey(u => u.ApplicationUserId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasMany(u => u.Cards).WithOne(u => u.User)
				.HasForeignKey(u => u.ApplicationUserId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}

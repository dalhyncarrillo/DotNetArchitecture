using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solution.Model.Models;

namespace Solution.Infrastructure.Databases.Database.EntityTypeConfigurations
{
	public sealed class UserRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserRoleModel>
	{
		public void Configure(EntityTypeBuilder<UserRoleModel> builder)
		{
			builder.ToTable("UsersRoles", "User");

			builder.HasKey(x => new { x.UserId, x.Role });

			builder.Property(x => x.Role).IsRequired().ValueGeneratedNever();
			builder.Property(x => x.UserId).IsRequired().ValueGeneratedNever();

			builder.HasOne(x => x.User).WithMany(x => x.UsersRoles).HasForeignKey(x => x.UserId);
		}
	}
}
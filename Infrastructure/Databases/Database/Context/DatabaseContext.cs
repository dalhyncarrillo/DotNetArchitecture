using Microsoft.EntityFrameworkCore;
using Solution.Infrastructure.Databases.Database.EntityTypeConfigurations;
using Solution.Model.Models;

namespace Solution.Infrastructure.Databases.Database.Context
{
	public sealed class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions options) : base(options) { }

		public DbSet<UserModel> Users { get; set; }
		public DbSet<UserLogModel> UsersLogs { get; set; }
		public DbSet<UserRoleModel> UsersRoles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ForSqlServerUseIdentityColumns();
			modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new UserLogEntityTypeConfiguration());
			modelBuilder.ApplyConfiguration(new UserRoleEntityTypeConfiguration());
		}
	}
}

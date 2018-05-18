using Solution.Infrastructure.Databases.Database.Repositories;

namespace Solution.Infrastructure.Databases.Database.UnitOfWork
{
	public interface IDatabaseUnitOfWork
	{
		IUserLogRepository UserLog { get; }
		IUserRepository User { get; }
		IUserRoleRepository UserRole { get; }

		void DiscardChanges();

		void SaveChanges();
	}
}

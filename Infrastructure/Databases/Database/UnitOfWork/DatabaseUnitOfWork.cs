using Solution.Infrastructure.Databases.Database.Context;
using Solution.Infrastructure.Databases.Database.Repositories;

namespace Solution.Infrastructure.Databases.Database.UnitOfWork
{
	public sealed class DatabaseUnitOfWork : IDatabaseUnitOfWork
	{
		public DatabaseUnitOfWork(
			DatabaseContext context,
			IUserRepository user,
			IUserLogRepository userLog,
			IUserRoleRepository userRole)
		{
			Context = context;
			User = user;
			UserLog = userLog;
			UserRole = userRole;
		}

		private DatabaseContext Context { get; set; }
		public IUserRepository User { get; }
		public IUserLogRepository UserLog { get; }
		public IUserRoleRepository UserRole { get; }

		public void DiscardChanges()
		{
			if (Context == null) { return; }
			Context.Dispose();
			Context = null;
		}

		public void SaveChanges()
		{
			Context.SaveChanges();
		}
	}
}
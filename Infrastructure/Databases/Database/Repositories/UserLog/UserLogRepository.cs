using Solution.Infrastructure.Databases.Database.Context;
using Solution.Infrastructure.Databases.EntityFrameworkCore;
using Solution.Model.Models;

namespace Solution.Infrastructure.Databases.Database.Repositories
{
	public sealed class UserLogRepository : EntityFrameworkCoreRepository<UserLogModel>, IUserLogRepository
	{
		public UserLogRepository(DatabaseContext context) : base(context) { }
	}
}

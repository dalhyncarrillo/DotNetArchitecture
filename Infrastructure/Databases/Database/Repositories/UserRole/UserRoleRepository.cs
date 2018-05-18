using Solution.Infrastructure.Databases.Database.Context;
using Solution.Infrastructure.Databases.EntityFrameworkCore;
using Solution.Model.Models;

namespace Solution.Infrastructure.Databases.Database.Repositories
{
	public sealed class UserRoleRepository : EntityFrameworkCoreRepository<UserRoleModel>, IUserRoleRepository
	{
		public UserRoleRepository(DatabaseContext context) : base(context) { }
	}
}

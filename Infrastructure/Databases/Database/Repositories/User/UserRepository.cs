using System.Linq;
using Solution.Infrastructure.Databases.Database.Context;
using Solution.Infrastructure.Databases.EntityFrameworkCore;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Infrastructure.Databases.Database.Repositories
{
	public sealed class UserRepository : EntityFrameworkCoreRepository<UserModel>, IUserRepository
	{
		public UserRepository(DatabaseContext context) : base(context)
		{
		}

		public AuthenticatedModel Authenticate(AuthenticationModel authentication)
		{
			return QueryableMapResult
			(
				select => new AuthenticatedModel
				{
					UserId = select.UserId,
					Roles = select.UsersRoles.Select(userRole => userRole.Role)
				},
				where =>
				(
					where.Login.Equals(authentication.Login) &&
					where.Password.Equals(authentication.Password) &&
					where.Status == Status.Active
				)
			)
			.SingleOrDefault();
		}
	}
}
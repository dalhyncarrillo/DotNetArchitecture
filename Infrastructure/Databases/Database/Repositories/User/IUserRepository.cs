using Solution.CrossCutting.Utils;
using Solution.Model.Models;

namespace Solution.Infrastructure.Databases.Database.Repositories
{
	public interface IUserRepository : IRepository<UserModel>
	{
		AuthenticatedModel Authenticate(AuthenticationModel authentication);
	}
}

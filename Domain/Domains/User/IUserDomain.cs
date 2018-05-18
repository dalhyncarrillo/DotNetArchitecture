using Solution.CrossCutting.Utils;
using Solution.Model.Models;

namespace Solution.Domain.Domains
{
	public interface IUserDomain : IBaseDomain
	{
		PagedList<UserModel> List(PagedListParameters parameters);

		UserModel Select(long userId);
	}
}

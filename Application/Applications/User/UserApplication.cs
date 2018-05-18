using Solution.CrossCutting.Utils;
using Solution.Domain.Domains;
using Solution.Model.Models;

namespace Solution.Application.Applications
{
	public sealed class UserApplication : BaseApplication, IUserApplication
	{
		public UserApplication(IUserDomain user)
		{
			User = user;
		}

		private IUserDomain User { get; }

		public PagedList<UserModel> List(PagedListParameters parameters)
		{
			return User.List(parameters);
		}

		public UserModel Select(long userId)
		{
			return User.Select(userId);
		}
	}
}

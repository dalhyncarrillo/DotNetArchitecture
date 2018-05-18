using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Domain.Domains
{
	public interface IUserLogDomain : IBaseDomain
	{
		void Add(UserLogModel userLog);

		void AddSaveChanges(UserLogModel userLog);

		UserLogModel Create(long userId, LogType logType);
	}
}

using System;
using Solution.Infrastructure.Databases.Database.UnitOfWork;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Domain.Domains
{
	public sealed class UserLogDomain : BaseDomain, IUserLogDomain
	{
		public UserLogDomain(IDatabaseUnitOfWork database)
		{
			Database = database;
		}

		private IDatabaseUnitOfWork Database { get; }

		public void Add(UserLogModel userLog)
		{
			Database.UserLog.Add(userLog);
		}

		public void AddSaveChanges(UserLogModel userLog)
		{
			Add(userLog);
			Database.SaveChanges();
		}

		public UserLogModel Create(long userId, LogType logType)
		{
			return new UserLogModel
			{
				UserId = userId,
				LogType = logType,
				DateTime = DateTime.UtcNow
			};
		}
	}
}

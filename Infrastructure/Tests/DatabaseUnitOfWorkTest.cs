using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.Infrastructure.Databases.Database.Context;
using Solution.Infrastructure.Databases.Database.UnitOfWork;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Infrastructure.Tests
{
	[TestClass]
	public class DatabaseUnitOfWorkTest
	{
		public DatabaseUnitOfWorkTest()
		{
			DependencyInjection.RegisterServices();
			DependencyInjection.AddDbContextInMemoryDatabase<DatabaseContext>();
			DatabaseUnitOfWork = DependencyInjection.GetService<IDatabaseUnitOfWork>();
		}

		private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

		[TestMethod]
		public void DatabaseUnitOfWork_Repositories()
		{
			/// Create
			var user = new UserModel
			{
				Name = "Name",
				Surname = "Surname",
				Email = "email@email.com",
				Login = "login",
				Password = "password",
				Status = Status.Active
			};

			/// Add
			DatabaseUnitOfWork.User.Add(user);
			DatabaseUnitOfWork.SaveChanges();

			/// Select
			var userExists = DatabaseUnitOfWork.User.Find(user.UserId);

			/// Update
			userExists.Name = "Updated";
			DatabaseUnitOfWork.User.Update(userExists, user.UserId);
			DatabaseUnitOfWork.SaveChanges();

			/// Delete
			DatabaseUnitOfWork.User.Delete(user.UserId);
			DatabaseUnitOfWork.SaveChanges();

			/// Count
			DatabaseUnitOfWork.User.Count();
		}
	}
}

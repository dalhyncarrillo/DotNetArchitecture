using Solution.CrossCutting.Security;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.Infrastructure.Databases.Database.Context
{
	public static class DatabaseContextExtensions
	{
		public static void Seed(this DatabaseContext context)
		{
			SeedUsers(context);
			context.SaveChanges();
		}

		private static void SeedUsers(DatabaseContext context)
		{
			if (context.Users.Find(1L) != null) { return; }

			var hash = new Hash();

			var userModel = new UserModel
			{
				Name = "Administrator",
				Surname = "Administrator",
				Email = "administrator@administrator.com",
				Login = hash.Generate("admin"),
				Password = hash.Generate("admin"),
				Status = Status.Active
			};

			var userRoleModel = new UserRoleModel { UserId = 1, Role = Roles.Admin };

			context.Users.Add(userModel);

			context.UsersRoles.Add(userRoleModel);
		}
	}
}
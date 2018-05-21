using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.Mapping;
using Solution.Model.Enums;
using Solution.Model.Models;

namespace Solution.CrossCutting.Tests
{
	[TestClass]
	public class MappingTest
	{
		public MappingTest()
		{
			DependencyInjection.DependencyInjection.RegisterServices();
			Mapping = DependencyInjection.DependencyInjection.GetService<IMapping>();
		}

		private IMapping Mapping { get; }

		[TestMethod]
		public void Mapping_Clone()
		{
			var source = new UserModel
			{
				Email = "email@mail.com",
				Login = "login",
				Name = "Name",
				Password = "password",
				UserId = 1
			};

			var result = Mapping.Clone(source);

			Assert.IsNotNull(result.UserId);
		}

		[TestMethod]
		public void Mapping_Map()
		{
			var source = new UserModel
			{
				UserId = 1,
				UsersRoles = new List<UserRoleModel>
				{
					new UserRoleModel
					{
						UserId = 1,
						Role = Roles.Admin
					}
				}
			};

			var result = Mapping.Map<AuthenticatedModel>(source);

			Assert.IsNotNull(result.UserId);
			Assert.IsNotNull(result.Roles);
			Assert.IsTrue(result.Roles.Any());
		}

		[TestMethod]
		public void Mapping_Merge()
		{
			var source = new UserModel
			{
				Name = "Name",
				UserId = 1
			};

			var destination = new UserModel
			{
				Email = "email@mail.com",
				Login = "login",
				Password = "password"
			};

			var result = Mapping.Map(source, destination);

			Assert.IsNotNull(result.Email);
			Assert.IsNotNull(result.Login);
			Assert.IsNotNull(result.Name);
			Assert.IsNotNull(result.Password);
			Assert.IsNotNull(result.UserId);
		}
	}
}

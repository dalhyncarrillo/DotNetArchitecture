using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.CrossCutting.Utils;
using Solution.Domain.Domains;
using Solution.Infrastructure.Databases.Database.Context;
using Solution.Model.Models;

namespace Solution.Domain.Tests
{
	[TestClass]
	public class DomainTest
	{
		public DomainTest()
		{
			DependencyInjection.RegisterServices();
			DependencyInjection.AddDbContextInMemoryDatabase<DatabaseContext>();
			DependencyInjection.GetService<DatabaseContext>().Seed();
			AuthenticationDomain = DependencyInjection.GetService<IAuthenticationDomain>();
			UserDomain = DependencyInjection.GetService<IUserDomain>();
		}

		private IAuthenticationDomain AuthenticationDomain { get; }
		private IUserDomain UserDomain { get; }

		[TestMethod]
		public void AuthenticationDomain_Authenticate_Exists()
		{
			var authenticationModel = new AuthenticationModel { Login = "admin", Password = "admin" };
			var result = AuthenticationDomain.Authenticate(authenticationModel);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		[ExpectedException(typeof(DomainException))]
		public void AuthenticationDomain_Authenticate_Inexists()
		{
			var result = AuthenticationDomain.Authenticate(new AuthenticationModel());
			Assert.IsNull(result);
		}

		[TestMethod]
		public void UserDomain_Select()
		{
			var result = UserDomain.Select(1);
			Assert.IsNotNull(result);
		}
	}
}

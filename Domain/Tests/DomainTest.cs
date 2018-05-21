using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.DependencyInjection;
using Solution.Domain.Domains;
using Solution.Infrastructure.Databases.Database.Context;

namespace Solution.Domain.Tests
{
	[TestClass]
	public class DomainTest
	{
		public DomainTest()
		{
			DependencyInjection.RegisterServices();
			DependencyInjection.AddDbContextInMemoryDatabase<DatabaseContext>();
			UserDomain = DependencyInjection.GetService<IUserDomain>();
		}

		private IUserDomain UserDomain { get; }

		[TestMethod]
		public void UserDomain_Select()
		{
			var user = UserDomain.Select(0);
			Assert.IsNull(user);
		}
	}
}

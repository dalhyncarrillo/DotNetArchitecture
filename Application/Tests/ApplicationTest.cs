using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.Application.Applications;
using Solution.CrossCutting.DependencyInjection;
using Solution.Infrastructure.Databases.Database.Context;

namespace Solution.Application.Tests
{
	[TestClass]
	public class ApplicationTest
	{
		public ApplicationTest()
		{
			DependencyInjection.RegisterServices();
			DependencyInjection.AddDbContextInMemoryDatabase<DatabaseContext>();
			DependencyInjection.GetService<DatabaseContext>().Seed();
			UserApplication = DependencyInjection.GetService<IUserApplication>();
		}

		private IUserApplication UserApplication { get; }

		[TestMethod]
		public void UserApplication_Select()
		{
			var result = UserApplication.Select(1);
			Assert.IsNotNull(result);
		}
	}
}

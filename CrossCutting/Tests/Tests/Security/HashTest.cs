using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.Security;

namespace Solution.CrossCutting.Tests
{
	[TestClass]
	public class HashTest
	{
		public HashTest()
		{
			DependencyInjection.DependencyInjection.RegisterServices();
			Hash = DependencyInjection.DependencyInjection.GetService<IHash>();
		}

		private IHash Hash { get; }

		[TestMethod]
		public void Hash_Generate()
		{
			var hash = Hash.Generate(nameof(Hash));
			Assert.IsNotNull(hash);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Hash_Generate_Empty()
		{
			Hash.Generate(string.Empty);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Hash_Generate_Null()
		{
			Hash.Generate(null);
		}
	}
}

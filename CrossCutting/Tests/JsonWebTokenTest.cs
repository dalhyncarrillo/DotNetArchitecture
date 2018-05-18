using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.Security;

namespace Solution.CrossCutting.Tests
{
	[TestClass]
	public class JsonWebTokenTest
	{
		public JsonWebTokenTest()
		{
			DependencyInjection.DependencyInjection.RegisterServices();
			JsonWebToken = DependencyInjection.DependencyInjection.GetService<IJsonWebToken>();
		}

		private IJsonWebToken JsonWebToken { get; }

		[TestMethod]
		public void JsonWebToken_Encode_Decode()
		{
			var encoded = JsonWebToken.Encode("sub", new[] { "admin" });
			var decoded = JsonWebToken.Decode(encoded);
			Assert.IsNotNull(decoded);
		}
	}
}

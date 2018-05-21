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
		public void JsonWebToken_EncodeDecode()
		{
			var encoded = JsonWebToken.Encode("sub", new[] { "admin" });
			var decoded = JsonWebToken.Decode(encoded);
			Assert.IsNotNull(decoded);
		}

		[TestMethod]
		public void JsonWebToken_GetTokenValidationParameters()
		{
			var parameters = JsonWebToken.GetTokenValidationParameters();
			Assert.IsNotNull(parameters);
		}
	}
}

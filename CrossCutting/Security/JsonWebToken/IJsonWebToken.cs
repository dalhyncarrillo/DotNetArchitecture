using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;

namespace Solution.CrossCutting.Security
{
	public interface IJsonWebToken
	{
		Dictionary<string, object> Decode(string token);

		string Encode(string sub, string[] roles);

		TokenValidationParameters GetTokenValidationParameters();
	}
}

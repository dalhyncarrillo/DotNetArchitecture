using Solution.Model.Models;

namespace Solution.Application.Applications
{
	public interface IAuthenticationApplication : IBaseApplication
	{
		AuthenticatedModel Authenticate(AuthenticationModel authentication);

		string GenerateJwt(AuthenticatedModel authenticated);

		void Logout(long userId);
	}
}

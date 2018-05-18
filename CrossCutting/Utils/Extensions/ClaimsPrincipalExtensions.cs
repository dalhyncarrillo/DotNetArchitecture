using System.Security.Claims;

namespace Solution.CrossCutting.Utils
{
	public static class ClaimsPrincipalExtensions
	{
		public static long GetAuthenticatedUserId(this ClaimsPrincipal claimsPrincipal)
		{
			long.TryParse(claimsPrincipal.GetClaimValueOfNameIdentifier(), out var userId);
			return userId;
		}

		public static Claim GetClaim(this ClaimsPrincipal claimsPrincipal, string claimType)
		{
			return claimsPrincipal?.FindFirst(claimType);
		}

		public static string GetClaimValueOfNameIdentifier(this ClaimsPrincipal claimsPrincipal)
		{
			return claimsPrincipal?.GetClaim(ClaimTypes.NameIdentifier)?.Value;
		}
	}
}

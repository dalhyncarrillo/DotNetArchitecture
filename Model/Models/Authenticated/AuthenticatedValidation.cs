using System.Linq;
using Solution.CrossCutting.Resources;
using Solution.CrossCutting.Utils;

namespace Solution.Model.Models
{
	public sealed class AuthenticatedValidation : Validation<AuthenticatedModel>
	{
		public override ValidationResult Validate(AuthenticatedModel obj)
		{
			var validationResult = new ValidationResult();

			if (obj == null || obj.UserId == 0 || obj.Roles?.Any() != true)
			{
				validationResult.Errors.Add(nameof(Texts.AuthenticationInvalid), Texts.AuthenticationInvalid);
			}

			return validationResult;
		}
	}
}

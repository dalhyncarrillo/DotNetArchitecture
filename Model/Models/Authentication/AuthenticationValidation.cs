using Solution.CrossCutting.Resources;
using Solution.CrossCutting.Utils;

namespace Solution.Model.Models
{
	public sealed class AuthenticationValidation : Validation<AuthenticationModel>
	{
		public override ValidationResult Validate(AuthenticationModel obj)
		{
			var validationResult = new ValidationResult();

			if (obj == null || string.IsNullOrEmpty(obj.Login) || string.IsNullOrEmpty(obj.Password))
			{
				validationResult.Errors.Add(nameof(Texts.AuthenticationInvalid), Texts.AuthenticationInvalid);
			}

			return validationResult;
		}
	}
}

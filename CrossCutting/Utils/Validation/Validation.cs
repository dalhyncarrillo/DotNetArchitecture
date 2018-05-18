using System.Linq;

namespace Solution.CrossCutting.Utils
{
	public abstract class Validation<T>
	{
		public abstract ValidationResult Validate(T obj);

		public void ValidateThrowException(T obj)
		{
			var validationResult = Validate(obj);
			if (validationResult.IsValid) { return; }
			var message = string.Join(" ", validationResult.Errors.Select(x => x.Value));
			throw new DomainException(message);
		}
	}
}

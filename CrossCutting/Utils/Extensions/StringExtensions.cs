using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solution.CrossCutting.Utils
{
	public static class StringExtensions
	{
		public static string CamelCase(this string value)
		{
			return char.ToLowerInvariant(value[0]) + value.Substring(1);
		}

		public static string RemoveSpecialCharacters(this string value)
		{
			var dictionary = new Dictionary<char, char[]>
			{
				{'a', new[] {'à', 'á', 'ä', 'â', 'ã'}},
				{'A', new[] {'À', 'Á', 'Ä', 'Â', 'Ã'}},
				{'c', new[] {'ç'}},
				{'C', new[] {'Ç'}},
				{'e', new[] {'è', 'é', 'ë', 'ê'}},
				{'E', new[] {'È', 'É', 'Ë', 'Ê'}},
				{'i', new[] {'ì', 'í', 'ï', 'î'}},
				{'I', new[] {'Ì', 'Í', 'Ï', 'Î'}},
				{'o', new[] {'ò', 'ó', 'ö', 'ô', 'õ'}},
				{'O', new[] {'Ò', 'Ó', 'Ö', 'Ô', 'Õ'}},
				{'u', new[] {'ù', 'ú', 'ü', 'û'}},
				{'U', new[] {'Ù', 'Ú', 'Ü', 'Û'}}
			};

			value = dictionary.Keys.Aggregate(value, (x, y) => dictionary[y].Aggregate(x, (z, c) => z.Replace(c, y)));
			return Regex.Replace(value, "[^0-9a-zA-Z._ ]+?", string.Empty);
		}
	}
}

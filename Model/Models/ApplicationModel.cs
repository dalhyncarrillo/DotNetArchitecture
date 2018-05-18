using System.Collections;
using Solution.CrossCutting.Resources;
using Solution.CrossCutting.Utils;

namespace Solution.Model.Models
{
	public class ApplicationModel
	{
		public IDictionary Texts { get; set; } = typeof(Texts).ToDictionary();
	}
}

using System;
using Solution.CrossCutting.Utils;

namespace Solution.CrossCutting.Logging
{
	public class Logging : ILogging
	{
		public void Error(Exception exception)
		{
			Console.WriteLine(exception.GetDetail());
		}

		public void Information(string message)
		{
			Console.WriteLine(message);
		}
	}
}

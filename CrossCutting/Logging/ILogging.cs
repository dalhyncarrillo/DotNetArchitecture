using System;

namespace Solution.CrossCutting.Logging
{
	public interface ILogging
	{
		void Error(Exception exception);

		void Information(string message);
	}
}

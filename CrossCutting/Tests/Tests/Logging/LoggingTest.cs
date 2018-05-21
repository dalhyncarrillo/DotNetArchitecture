using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.Logging;

namespace Solution.CrossCutting.Tests
{
	[TestClass]
	public class LoggingTest
	{
		public LoggingTest()
		{
			DependencyInjection.DependencyInjection.RegisterServices();
			Logging = DependencyInjection.DependencyInjection.GetService<ILogging>();
		}

		private ILogging Logging { get; }

		[TestMethod]
		public void Logging_Error()
		{
			Logging.Error(new Exception(nameof(Exception)));
		}

		[TestMethod]
		public void Logging_Information()
		{
			Logging.Information(nameof(Logging.Information));
		}
	}
}

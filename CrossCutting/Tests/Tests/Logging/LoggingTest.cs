using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.Logging;
using Solution.CrossCutting.Utils;

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
			Logging.Error(new DomainException(nameof(DomainException)));
		}

		[TestMethod]
		public void Logging_Information()
		{
			Logging.Information(nameof(Logging.Information));
		}
	}
}

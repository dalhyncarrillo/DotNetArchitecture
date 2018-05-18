using System;
using System.Diagnostics;
using System.Text;

namespace Solution.CrossCutting.Utils
{
	public static class ExceptionExtensions
	{
		public static string GetDetail(this Exception exception)
		{
			if (exception == null) { return string.Empty; }

			var stackFrame = new StackTrace(exception, true).GetFrame(0);

			var sb = new StringBuilder();

			sb.Append($"ERROR: '{exception.Message}' ");

			sb.Append($"FILE: '{stackFrame.GetMethod().DeclaringType}' ");

			sb.Append($"LINE: {stackFrame.GetFileLineNumber()}.");

			return sb.ToString();
		}
	}
}

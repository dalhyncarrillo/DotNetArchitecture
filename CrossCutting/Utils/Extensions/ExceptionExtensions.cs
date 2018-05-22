using System;
using System.Diagnostics;
using System.Text;

namespace Solution.CrossCutting.Utils
{
	public static class ExceptionExtensions
	{
		public static string GetDetail(this Exception exception)
		{
			var sb = new StringBuilder();

			sb.Append("ERROR: ").Append(exception.Message).Append(". ");

			var stackFrame = new StackTrace(exception, true).GetFrame(0);

			if (stackFrame != null)
			{
				sb.Append("FILE: ").Append(stackFrame.GetMethod().DeclaringType).Append(". ");
				sb.Append("LINE: ").Append(stackFrame.GetFileLineNumber()).Append(".");
			}

			return sb.ToString();
		}
	}
}

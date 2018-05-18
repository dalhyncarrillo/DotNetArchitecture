using System;
using Solution.Model.Enums;

namespace Solution.Model.Models
{
	public class UserLogModel
	{
		public DateTime DateTime { get; set; }

		public LogType LogType { get; set; }

		public string Message { get; set; }

		public long UserId { get; set; }

		public long UserLogId { get; set; }

		#region Related

		public virtual UserModel User { get; set; }

		#endregion Related
	}
}

using System;
using System.IO;

namespace DLUSchedule.Models
{
	public static class Constants
	{
		public const string DatabaseFilename = "DLUSQLite.db3";

		public const SQLite.SQLiteOpenFlags Flags =
			// open the database in read/write mode
			SQLite.SQLiteOpenFlags.ReadWrite |
			// create the database if it doesn't exist
			SQLite.SQLiteOpenFlags.Create |
			// enable multi-threaded database access
			SQLite.SQLiteOpenFlags.SharedCache;

		public static string DatabasePath
		{
			get
			{
				var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				return Path.Combine(basePath, DatabaseFilename);
			}
		}

		public const string RegexSubjectName = @"-Môn: (.*)\)-";

		public const string RegexSubjectGroup = @"-Nhóm: [0-9]{2}-";

		public const string RegexSubjectClass = @"-Lớp: (.*)-Tiết";

		public const string RegexSubjectPeriod = @"-Tiết: (.*)-Đã dạy";

		public const string RegexSubjectTaught = @"-Đã dạy: (.*)-Phòng";

		public const string RegexSubjectRoom = @"-Phòng : (.*)";

		public readonly static string[] DayOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
	}
}

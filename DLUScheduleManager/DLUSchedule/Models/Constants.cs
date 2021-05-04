namespace DLUSchedule.Models
{
	public static class Constants
	{
		public const string RegexSubjectName = @"-Môn: (.*)\)-";

		public const string RegexSubjectGroup = @"-Nhóm: [0-9]{2}-";

		public const string RegexSubjectClass = @"-Lớp: (.*)-Tiết";

		public const string RegexSubjectPeriod = @"-Tiết: (.*)-Đã dạy";

		public const string RegexSubjectTaught = @"-Đã dạy: (.*)-Phòng";

		public const string RegexSubjectRoom = @"-Phòng : (.*)";

		public readonly static string[] DayOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
		public const string DBName = "DLUSchedule.db";
	}
}

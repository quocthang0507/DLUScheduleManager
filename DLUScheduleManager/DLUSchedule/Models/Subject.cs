using DLUSchedule.Utils;
using System;
using System.Text.RegularExpressions;

namespace DLUSchedule.Models
{
	/// <summary>
	/// Môn học
	/// </summary>
	public class Subject
	{
		private readonly Regex regexName = new Regex(Constants.RegexSubjectName, RegexOptions.Compiled | RegexOptions.IgnoreCase);
		private readonly Regex regexGroup = new Regex(Constants.RegexSubjectGroup, RegexOptions.Compiled | RegexOptions.IgnoreCase);
		private readonly Regex regexClass = new Regex(Constants.RegexSubjectClass, RegexOptions.Compiled | RegexOptions.IgnoreCase);
		private readonly Regex regexPeriod = new Regex(Constants.RegexSubjectPeriod, RegexOptions.Compiled | RegexOptions.IgnoreCase);
		private readonly Regex regexTaught = new Regex(Constants.RegexSubjectTaught, RegexOptions.Compiled | RegexOptions.IgnoreCase);
		private readonly Regex regexRoom = new Regex(Constants.RegexSubjectRoom, RegexOptions.Compiled | RegexOptions.IgnoreCase);

		/// <summary>
		/// Tên học phần (và mã học phần)
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Nhóm
		/// </summary>
		public int Group { get; set; }
		/// <summary>
		/// Lớp
		/// </summary>
		public string Class { get; set; }
		/// <summary>
		/// Tiết bắt đầu và kết thúc
		/// </summary>
		public string Period { get; set; }
		/// <summary>
		/// Số tiết đã dạy
		/// </summary>
		public string TaughtSession { get; set; }
		/// <summary>
		/// Phòng
		/// </summary>
		public string RoomID { get; set; }

		public Subject(string description)
		{
			if (!string.IsNullOrWhiteSpace(description))
			{
				Match name = regexName.Match(description);
				Match group = regexGroup.Match(description);
				Match @class = regexClass.Match(description);
				Match period = regexPeriod.Match(description);
				Match taught = regexTaught.Match(description);
				Match room = regexRoom.Match(description);

				this.Name = name.Value.Remove(name.Value.Length - 1).Replace("-Môn: ", "");
				this.Group = Convert.ToInt32(group.Value.Remove(group.Value.Length - 1).Replace("-Nhóm: ", ""));
				this.Class = @class.Value.Replace("-Lớp: ", "").Replace("-Tiết", "");
				this.Period = period.Value.Replace("-Tiết: ", "").Replace("-Đã dạy", "");
				this.TaughtSession = taught.Value.Replace("-Đã dạy: ", "").Replace("-Phòng", "");
				this.RoomID = room.Value.Replace("-Phòng : ", "");
			}
		}

		public override string ToString()
		{
			if (Common.IsNullOrWhitespace(Name, @Class, Period, TaughtSession, RoomID))
				return string.Empty;
			return $"- Môn: {Name}\n- Nhóm: {Group}\n- Lớp: {Class}\n- Tiết: {Period}\n- Đã dạy: {TaughtSession}\n- Phòng: {RoomID}";
		}
	}
}

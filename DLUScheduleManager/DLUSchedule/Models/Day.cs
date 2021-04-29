using System.Collections.Generic;

namespace DLUSchedule.Models
{
	/// <summary>
	/// Lịch theo ngày
	/// </summary>
	public class Day
	{
		/// <summary>
		/// Thứ trong tuần
		/// </summary>
		public string DayOfWeek { get; set; }
		/// <summary>
		/// Các môn học trong ngày
		/// </summary>
		public List<Subject> Subjects = new List<Subject>();
	}
}

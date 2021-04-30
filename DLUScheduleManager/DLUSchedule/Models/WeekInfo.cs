using DLUSchedule.Utils;
using System;

namespace DLUSchedule.Models
{
	/// <summary>
	/// Tuần học (lấy từ hệ thống Quản lý giảng đường)
	/// </summary>
	public class WeekInfo
	{
		/// <summary>
		/// Số tuần (dạng số)
		/// </summary>
		public int Week { get; set; }
		/// <summary>
		/// Số tuần (dạng chữ)
		/// </summary>
		public string Week2 { get; set; }
		/// <summary>
		/// Số tuần hiển thị trên hệ thống
		/// </summary>
		public int DisPlayWeek { get; set; }
		/// <summary>
		/// Số tuần trong năm (dạng số)
		/// </summary>
		public int WeekOfYear { get; set; }
		/// <summary>
		/// Số tuần trong năm (dạng chữ)
		/// </summary>
		public string WeekOfYear2 { get; set; }
		/// <summary>
		/// Lấy ngày bắt đầu của tuần
		/// </summary>
		public DateTime GetFirstDayOfWeek
		{
			get
			{
				string[] arr = Week2.Split('$');
				int week = Convert.ToInt32(arr[0]) - 1, year = Convert.ToInt32(arr[1]);
				return Common.GetFirstDayOfWeek(year, week, DayOfWeek.Monday);
			}
		}
	}
}

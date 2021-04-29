using DLUSchedule.Models;
using DLUSchedule.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DLUSchedule.Services
{
	/// <summary>
	/// Lấy thông tin tuần học từ hệ thống quản lý giảng đường
	/// </summary>
	public class MockWeekData
	{
		/// <summary>
		/// Danh sách tuần theo học kỳ
		/// </summary>
		public List<WeekInfo> All { get; protected set; }

		public MockWeekData(List<WeekInfo> weeks)
		{
			All = weeks;
		}

		public MockWeekData(string schoolyear, string semester)
		{
			if (Common.IsNullOrWhitespace(schoolyear, semester))
				throw new ArgumentNullException("Please use the constructor with two parameters first");
			string url = $"http://qlgd.dlu.edu.vn/Public/GetWeek/{schoolyear}${semester}";
			All = Common.GetJsonsFromURL<WeekInfo>(url);
		}

		/// <summary>
		/// Đổi tuần hiển thị sang tuần thực tế
		/// </summary>
		/// <param name="week"></param>
		/// <returns></returns>
		public int DisplayWeekToRealWeek(int week)
		{
			var result = All.First(x => x.DisPlayWeek == week);
			return result.Week;
		}

		/// <summary>
		/// Đổi tuần thực tế sang tuần hiển thị
		/// </summary>
		/// <param name="week"></param>
		/// <returns></returns>
		public int RealWeekToDisplayWeek(int week)
		{
			var result = All.First(x => x.Week == week);
			return result.DisPlayWeek;
		}
	}
}

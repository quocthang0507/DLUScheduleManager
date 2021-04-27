using DLUSchedule.Models;
using DLUSchedule.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DLUSchedule.Services
{
	public class MockWeekData
	{
		public List<WeekInfo> Items { get; protected set; }

		public MockWeekData(List<WeekInfo> weeks)
		{
			Items = weeks;
		}

		public MockWeekData(string schoolyear, string semester)
		{
			if (Common.IsNullOrWhitespace(schoolyear, semester))
				throw new ArgumentNullException("Please use the constructor with two parameters first");
			string url = $"http://qlgd.dlu.edu.vn/Public/GetWeek/{schoolyear}${semester}";
			Items = Common.GetJsonsFromURL<WeekInfo>(url);
		}

		public int DisplayWeekToRealWeek(int week)
		{
			var result = Items.First(x => x.DisPlayWeek == week);
			return result.Week;
		}

		public int RealWeekToDisplayWeek(int week)
		{
			var result = Items.First(x => x.Week == week);
			return result.DisPlayWeek;
		}
	}
}

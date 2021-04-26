using DLUSchedule.Models;
using DLUSchedule.Utils;
using System.Collections.Generic;
using System.Linq;

namespace DLUSchedule.Services
{
	public class MockWeekData
	{
		public readonly List<WeekInfo> Items;

		public MockWeekData(string schoolyear, string semester)
		{
			string url = $"http://qlgd.dlu.edu.vn/Public/GetWeek/{schoolyear}${semester}";
			Items = Common.GetItemsInURL<WeekInfo>(url);
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

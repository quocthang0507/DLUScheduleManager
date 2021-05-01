using DLUSchedule.Models;
using DLUSchedule.Utils;
using DLUSchedule.Views;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DLUSchedule.Services
{
	/// <summary>
	/// Lấy thời khóa biểu của giảng viên tại thời điểm xác định từ hệ thống quản lý giảng đường
	/// </summary>
	public class MockSheduleData
	{
		private HtmlDocument htmlDoc;
		private int weekNumber;
		private DateTime beginDate;
		private string[] dayOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

		/// <summary>
		/// Thời khóa biểu các ngày trong tuần
		/// </summary>
		public List<Day> WeekSchedule { get; protected set; }
		public string HtmlSchedule { get; protected set; }

		public MockSheduleData(List<Day> weekSchedule)
		{
			WeekSchedule = weekSchedule;
		}

		public MockSheduleData(string schoolyear, string semester, int weekNumber, string professorID)
		{
			this.weekNumber = weekNumber;
			WeekSchedule = new List<Day>();
			if (Common.IsNullOrWhitespace(schoolyear, semester, professorID))
				throw new ArgumentNullException("Please use the constructor with four parameters first");
			string url = $"http://qlgd.dlu.edu.vn/Public/DrawingProfessorSchedule?YearStudy={schoolyear}&TermID={semester}&Week={weekNumber}&ProfessorID={professorID}";
			ParseHtml(url);
		}

		/// <summary>
		/// Chuyển bảng thời khóa biểu sang đối tượng quản lý
		/// </summary>
		/// <param name="url"></param>
		private void ParseHtml(string url)
		{
			HtmlWeb htmlWeb = new HtmlWeb();
			htmlDoc = htmlWeb.Load(url);
			HtmlSchedule = htmlDoc.Text;
			//List<List<string>> table = htmlDoc.DocumentNode.SelectSingleNode("//table")
			//	.Descendants("tr")
			//	.Skip(1) // Skip <th>
			//	.Where(tr => tr.Elements("td").Count() > 1)
			//	.Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
			//	.ToList();
			//beginDate = HomePage.Instance.MWeeks.All.First(x => x.Week == weekNumber).GetFirstDayOfWeek;
			//for (int i = 0; i < 7; i++)
			//{
			//	List<string> row = table[i];
			//	Day day = new Day();
			//	day.Date = beginDate.AddDays(i);
			//	day.DayOfWeek = Properties.Resources.ResourceManager.GetString(dayOfWeek[i]);
			//	day.DayOfWeek += $"\n({day.Date.ToString("d", Properties.Resources.Culture)})";
			//	foreach (var session in row)
			//	{
			//		Subject subject = new Subject(session);
			//		day.Subjects.Add(subject);
			//	}
			//	WeekSchedule.Add(day);
			//}
		}
	}
}

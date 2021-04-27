using DLUSchedule.Models;
using DLUSchedule.Utils;
using System;
using System.Collections.Generic;

namespace DLUSchedule.Services
{
	public class MockSheduleData
	{
		public List<Day> WeekSchedule { get; protected set; }
		public string HTML { get; protected set; }

		public MockSheduleData(List<Day> weekSchedule)
		{
			WeekSchedule = weekSchedule;
		}

		public MockSheduleData(string schoolyear, string semester, int weekNumber, string professorID)
		{
			if (Common.IsNullOrWhitespace(schoolyear, semester, professorID))
				throw new ArgumentNullException("Please use the constructor with four parameters first");
			string url = $"http://qlgd.dlu.edu.vn/Public/DrawingProfessorSchedule?YearStudy={schoolyear}&TermID={semester}&Week={weekNumber}&ProfessorID={professorID}";
			HTML = Common.GetHTMLFromURL(url);
		}
	}
}

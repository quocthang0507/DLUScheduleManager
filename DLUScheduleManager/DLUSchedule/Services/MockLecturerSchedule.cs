using DLUSchedule.Models;
using DLUSchedule.Utils;
using System;
using System.Collections.Generic;

namespace DLUSchedule.Services
{
	public class MockLecturerSchedule
	{
		private readonly string HTML;

		public List<Day> WeekSchedule { get; protected set; }

		public MockLecturerSchedule(List<Day> weekSchedule)
		{
			WeekSchedule = weekSchedule;
		}

		public MockLecturerSchedule(string schoolyear, string semester, int weekNumber, string professorID)
		{
			if (Common.IsNullOrWhitespace(schoolyear, semester, professorID))
				throw new ArgumentNullException("Please use the constructor with four parameters first");
			string url = $"http://online.dlu.edu.vn/Home/DrawingProfessorSchedule?YearStudy={schoolyear}&TermID={semester}&Week={weekNumber}&ProfessorID={professorID}";
			HTML = Common.GetHTMLFromURL(url);
		}
	}
}

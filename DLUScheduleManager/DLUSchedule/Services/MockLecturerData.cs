using DLUSchedule.Models;
using DLUSchedule.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLUSchedule.Services
{
	public class MockLecturerData
	{
		private string schoolyear;
		private string semester;

		public List<Lecturer> Items { get; protected set; }

		public MockLecturerData(List<Lecturer> lecturers)
		{
			Items = lecturers;
		}

		public MockLecturerData(string schoolyear, string semester)
		{
			this.schoolyear = schoolyear;
			this.semester = semester;
		}

		public async Task CreateAsync()
		{
			if (Common.IsNullOrWhitespace(schoolyear, semester))
				throw new ArgumentNullException("Please use the constructor with two parameters first");
			string url = $"http://qlgd.dlu.edu.vn/Public/GetProfessorByTerm/{schoolyear}${semester}";
			Items = await Common.GetJsonsFromURLAsync<Lecturer>(url);
		}

		public string FindNameByID(string id)
		{
			return Items.First(x => x.ProfessorID == id).ProfessorName;
		}

		public string FindIDByName(string name)
		{
			return Items.First(x => x.ProfessorName == name).ProfessorID;
		}
	}
}

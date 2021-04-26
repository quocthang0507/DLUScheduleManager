using DLUSchedule.Models;
using DLUSchedule.Utils;
using System.Collections.Generic;
using System.Linq;

namespace DLUSchedule.Services
{
	public class MockLecturerData
	{
		public readonly List<Lecturer> Items;

		public MockLecturerData(List<Lecturer> lecturers)
		{
			Items = lecturers;
		}

		public MockLecturerData(string schoolyear, string semester)
		{
			string url = $"http://qlgd.dlu.edu.vn/Public/GetProfessorByTerm/{schoolyear}${semester}";
			Items = Common.GetItemsInURL<Lecturer>(url);
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

using DLUSchedule.Models;
using DLUSchedule.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DLUSchedule.Services
{
	/// <summary>
	/// Lớp lấy dữ liệu thông tin giảng viên từ hệ thống quản lý giảng đường
	/// </summary>
	public class MockLecturerData
	{
		/// <summary>
		/// Danh sách giảng viên
		/// </summary>
		public List<Lecturer> All { get; protected set; }

		public MockLecturerData(List<Lecturer> lecturers)
		{
			All = lecturers;
		}

		public MockLecturerData(string schoolyear, string semester)
		{
			if (Common.IsNullOrWhitespace(schoolyear, semester))
				throw new ArgumentNullException("Please use the constructor with two parameters first");
			string url = $"http://qlgd.dlu.edu.vn/Public/GetProfessorByTerm/{schoolyear}${semester}";
			All = Common.GetJsonsFromURL<Lecturer>(url);
		}

		/// <summary>
		/// Tìm tên giảng viên theo mã giảng viên
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public string FindNameByID(string id)
		{
			return All.First(x => x.ProfessorID == id).ProfessorName;
		}

		/// <summary>
		/// Tìm mã giảng viên (có thể nhiều) theo tên
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public List<string> FindIDByName(string name)
		{
			return All.Where(x => x.ProfessorName == name).Select(x => x.ProfessorID).ToList();
		}
	}
}

using SQLite;

namespace DLUSchedule.Models
{
	/// <summary>
	/// Thông tin giảng viên (Lấy từ hệ thống quản lý giảng đường)
	/// </summary>
	public class Lecturer
	{
		/// <summary>
		/// Mã giảng viên
		/// </summary>
		[PrimaryKey]
		public string ProfessorID { get; set; }
		/// <summary>
		/// Tên giảng viên
		/// </summary>
		public string ProfessorName { get; set; }
	}
}

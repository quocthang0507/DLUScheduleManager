using SQLite;

namespace DLUSchedule.Models
{
	public class Login
	{
		[PrimaryKey]
		public string ProfessorId { get; set; }
		public string ProfessorName { get; set; }
		public string Schoolyear { get; set; }
		public string Semester { get; set; }
		public int Week { get; set; }
	}
}

using SQLite;

namespace DLUSchedule.Models
{
	public class Lecturer
	{
		[PrimaryKey]
		public string ProfessorID { get; set; }
		public string ProfessorName { get; set; }
	}
}

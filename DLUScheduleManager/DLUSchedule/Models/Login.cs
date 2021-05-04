namespace DLUSchedule.Models
{
	public class Login
	{
		public string Schoolyear { get; set; }
		public string Semester { get; set; }
		public Lecturer Lecturer = new Lecturer();
		public int Week { get; set; }
	}
}

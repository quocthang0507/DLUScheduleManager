using Xamarin.Forms;

namespace DLUSchedule.ViewModels
{
	[QueryProperty(nameof(Schoolyear), nameof(Schoolyear)),
		QueryProperty(nameof(Semester), nameof(Semester)),
		QueryProperty(nameof(Week), nameof(Week)),
		QueryProperty(nameof(ProfessorID), nameof(ProfessorID))]
	public class ScheduleViewModel : BaseViewModel
	{
		public string Schoolyear { get; set; }
		public string Semester { get; set; }
		public string ProfessorID { get; set; }
		public int Week { get; set; }

		public ScheduleViewModel()
		{
			Title = "Lịch";
		}
	}
}

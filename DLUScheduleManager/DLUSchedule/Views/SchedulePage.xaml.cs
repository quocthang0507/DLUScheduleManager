using DLUSchedule.Services;
using DLUSchedule.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DLUSchedule.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SchedulePage : ContentPage
	{
		private readonly ScheduleViewModel model = new ScheduleViewModel();

		public MockSheduleData MSchedule { get; protected set; }

		public SchedulePage()
		{
			InitializeComponent();
			BindingContext = model;

			Appearing += SchedulePage_Appearing;
		}

		#region Events
		private void SchedulePage_Appearing(object sender, System.EventArgs e)
		{
			MSchedule = new MockSheduleData(model.Schoolyear, model.Semester, model.Week, model.ProfessorID);
		}
		#endregion

		#region Methods

		#endregion
	}
}
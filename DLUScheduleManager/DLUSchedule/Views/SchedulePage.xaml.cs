using DLUSchedule.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DLUSchedule.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SchedulePage : ContentPage
	{
		private ScheduleViewModel model = new ScheduleViewModel();

		public SchedulePage()
		{
			InitializeComponent();
			BindingContext = model;
		}

		#region Events

		#endregion

		#region Methods

		#endregion
	}
}
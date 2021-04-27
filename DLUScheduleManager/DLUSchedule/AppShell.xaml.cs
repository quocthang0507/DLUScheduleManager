using DLUSchedule.Views;
using Xamarin.Forms;

namespace DLUSchedule
{
	public partial class AppShell : Xamarin.Forms.Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(SchedulePage), typeof(SchedulePage));
		}
	}
}

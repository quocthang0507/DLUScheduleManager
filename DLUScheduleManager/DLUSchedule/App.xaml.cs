using DLUSchedule.Views;
using Xamarin.Forms;

namespace DLUSchedule
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			MainPage = HomePage.Singleton;

			Routing.RegisterRoute(nameof(SchedulePage), typeof(SchedulePage));
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}

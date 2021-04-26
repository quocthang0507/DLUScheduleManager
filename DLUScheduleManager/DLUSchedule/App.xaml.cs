using DLUSchedule.Utils;
using DLUSchedule.Views;
using Xamarin.Forms;

namespace DLUSchedule
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			MainPage = !Common.IsConnectedToInternet() ? new HomePage(true) : new HomePage();
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

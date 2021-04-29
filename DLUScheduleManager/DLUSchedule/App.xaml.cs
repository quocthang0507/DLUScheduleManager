using System.Globalization;
using System.Threading;
using Xamarin.Forms;

namespace DLUSchedule
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi");
			DLUSchedule.Properties.Resources.Culture = new CultureInfo("vi");

			MainPage = new AppShell();
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

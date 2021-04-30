namespace DLUSchedule.UWP
{
	public sealed partial class MainPage
	{
		public MainPage()
		{
			this.InitializeComponent();

			Syncfusion.SfDataGrid.XForms.UWP.SfDataGridRenderer.Init();

			LoadApplication(new DLUSchedule.App());
		}
	}
}

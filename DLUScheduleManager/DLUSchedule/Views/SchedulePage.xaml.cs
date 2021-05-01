using DLUSchedule.Models;
using DLUSchedule.Services;
using DLUSchedule.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DLUSchedule.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SchedulePage : ContentPage
	{
		private ScheduleViewModel model = new ScheduleViewModel();

		public MockSheduleData MSchedule { get; protected set; }

		public SchedulePage()
		{
			Xamarin.Forms.DataGrid.DataGridComponent.Init();
			InitializeComponent();

			BindingContext = model;

			Appearing += SchedulePage_Appearing;
		}

		#region Events
		private void SchedulePage_Appearing(object sender, System.EventArgs e)
		{
			Task.Run(() =>
			{
				MSchedule = new MockSheduleData(model.Schoolyear, model.Semester, model.Week, model.ProfessorID);
				//List<DisplayedDay> days = new List<DisplayedDay>();
				//foreach (var day in MSchedule.WeekSchedule)
				//{
				//	ParseSessions(day, out string morning, out string afternoon, out string night);
				//	days.Add(new DisplayedDay(day.DayOfWeek, morning, afternoon, night));
				//}
				//Application.Current.Dispatcher.BeginInvokeOnMainThread(() =>
				//{
				//	ChangeRowHeight(days);
				//});
				//model.ItemsSource = days;
				Application.Current.Dispatcher.BeginInvokeOnMainThread(() =>
				{
					webviewSchedule.Source = new HtmlWebViewSource { Html = MSchedule.HtmlSchedule };
				});
			});
		}

		#endregion

		#region Methods
		private void ParseSessions(Day daySchedule, out string morning, out string afternoon, out string night)
		{
			morning = afternoon = night = string.Empty;
			foreach (var subject in daySchedule.Subjects)
			{
				if (!string.IsNullOrWhiteSpace(subject.Name))
				{
					int begin = Convert.ToInt32(subject.Period.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries)[0]);
					if (begin >= 11)
						night += $"{subject}\n";
					else if (begin >= 7)
						afternoon += $"{subject}\n";
					else
						morning += $"{subject}\n";
				}
			}
		}

		private int GetMaxLinesToDisplay(DisplayedDay day)
		{
			int c1 = day.Morning.Count(c => c == '\n'),
			c2 = day.Afternoon.Count(c => c == '\n'),
			c3 = day.Night.Count(c => c == '\n');
			return Math.Max(2, Math.Max(c1, Math.Max(c2, c3)));
		}

		//private void ChangeRowHeight(List<DisplayedDay> days)
		//{
		//	var max = days.Select(x => GetMaxLinesToDisplay(x)).Max();
		//	gridSchedule.RowHeight = max * 25;
		//}
		#endregion
	}
}
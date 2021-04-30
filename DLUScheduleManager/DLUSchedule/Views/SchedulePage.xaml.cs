using DLUSchedule.Models;
using DLUSchedule.Services;
using DLUSchedule.ViewModels;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Data;
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
			InitializeComponent();
			gridSchedule.GridStyle.GridCellBorderColor = Color.Black;
			gridSchedule.GridStyle.HeaderCellBorderColor = Color.Black;
			gridSchedule.QueryRowHeight += GridSchedule_QueryRowHeight;

			BindingContext = model;

			Appearing += SchedulePage_Appearing;
		}

		#region Events
		private void SchedulePage_Appearing(object sender, System.EventArgs e)
		{
			Task.Run(() =>
			{
				MSchedule = new MockSheduleData(model.Schoolyear, model.Semester, model.Week, model.ProfessorID);
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(Properties.Resources.DayOfWeek, typeof(string));
				dataTable.Columns.Add(Properties.Resources.Morning, typeof(string));
				dataTable.Columns.Add(Properties.Resources.Afternoon, typeof(string));
				dataTable.Columns.Add(Properties.Resources.Night, typeof(string));
				foreach (var day in MSchedule.WeekSchedule)
				{
					ParseSessions(day, out string morning, out string afternoon, out string night);
					dataTable.Rows.Add(day.DayOfWeek, morning, afternoon, night);
				}
				Application.Current.Dispatcher.BeginInvokeOnMainThread(() =>
				{
					gridSchedule.ItemsSource = dataTable;
				});
			});
		}

		private void GridSchedule_QueryRowHeight(object sender, QueryRowHeightEventArgs e)
		{
			if (e.RowIndex > 0)
			{
				e.Height = SfDataGridHelpers.GetRowHeight(gridSchedule, e.RowIndex);
				e.Handled = true;
			}
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
		#endregion
	}
}
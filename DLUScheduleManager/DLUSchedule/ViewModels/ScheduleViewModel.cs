using DLUSchedule.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DLUSchedule.ViewModels
{
	[QueryProperty(nameof(Schoolyear), nameof(Schoolyear)),
		QueryProperty(nameof(Semester), nameof(Semester)),
		QueryProperty(nameof(Week), nameof(Week)),
		QueryProperty(nameof(ProfessorID), nameof(ProfessorID))]
	public class ScheduleViewModel : BaseViewModel, INotifyPropertyChanged
	{
		private string dayOfWeek, morning, afternoon, night;
		private bool isRefreshing;
		private List<DisplayedDay> itemsSource = new List<DisplayedDay>();

		public string Schoolyear { get; set; }
		public string Semester { get; set; }
		public string ProfessorID { get; set; }
		public int Week { get; set; }
		public ICommand RefreshCommand { get; set; }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
		public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

		public string DayOfWeek
		{
			get
			{
				return dayOfWeek;
			}
			set
			{
				dayOfWeek = value;
				PropertyChanged(this, new PropertyChangedEventArgs("DayOfWeek"));
			}
		}

		public string Morning
		{
			get
			{
				return morning;
			}
			set
			{
				morning = value;
				PropertyChanged(this, new PropertyChangedEventArgs("Morning"));
			}
		}

		public string Afternoon
		{
			get
			{
				return afternoon;
			}
			set
			{
				afternoon = value;
				PropertyChanged(this, new PropertyChangedEventArgs("Afternoon"));
			}
		}

		public string Night
		{
			get
			{
				return night;
			}
			set
			{
				night = value;
				PropertyChanged(this, new PropertyChangedEventArgs("Night"));
			}
		}

		public bool IsRefreshing
		{
			get
			{
				return isRefreshing;
			}
			set
			{
				isRefreshing = value;
				PropertyChanged(this, new PropertyChangedEventArgs("IsRefreshing"));
			}
		}

		public List<DisplayedDay> ItemsSource
		{
			get { return itemsSource; }
			set 
			{ 
				itemsSource = value;
				PropertyChanged(this, new PropertyChangedEventArgs("ItemsSource")); 
				UpdateRowHeight(value);
			}
		}

		public ScheduleViewModel()
		{
			RefreshCommand = new Command(CommandRefresh);
		}

#pragma warning disable VSTHRD100 // Avoid async void methods
		private async void CommandRefresh()
#pragma warning restore VSTHRD100 // Avoid async void methods
		{
			IsRefreshing = true;
			await Task.Delay(3000);
			IsRefreshing = false;
		}

		private void UpdateRowHeight(List<DisplayedDay> value)
		{
		}
	}
}

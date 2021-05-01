using DLUSchedule.Utils;
using DLUSchedule.Views;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace DLUSchedule.ViewModels
{
	public class HomeViewModel : BaseViewModel, INotifyPropertyChanged
	{
		private string schoolyear;
		private string semester;
		private string fullname;
		private int week;
		private bool isSaved;

		public Action DisplayAlertAction;
		public Action ReloadAction;
		public ICommand SubmitCommand { protected set; get; }
		public ICommand ReloadCommand { protected set; get; }
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
		public event PropertyChangedEventHandler PropertyChanged = delegate { };
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

		public string Schoolyear
		{
			get { return schoolyear; }
			set
			{
				schoolyear = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Schoolyear)));
			}
		}
		public string Semester
		{
			get { return semester; }
			set
			{
				semester = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Semester)));
			}
		}
		public string Fullname
		{
			get { return fullname; }
			set
			{
				fullname = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Fullname)));
			}
		}
		public int Week
		{
			get { return week; }
			set
			{
				week = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Week)));
			}
		}
		public bool IsSaved
		{
			get { return isSaved; }
			set
			{
				isSaved = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsSaved)));
			}
		}

		public HomeViewModel()
		{
			SubmitCommand = new Command(OnSubmit);
			ReloadCommand = new Command(OnReload);
			Title = "Trang chủ";
		}

		private void OnReload(object obj)
		{
			ReloadAction();
		}

		private void OnSubmit(object obj)
		{
			if (Common.IsNullOrWhitespace(schoolyear, fullname, semester))
				DisplayAlertAction();
			else
			{
				if (isSaved)
					HomePage.LiteDB.Insert(this);
				string professorID = HomePage.Instance.MLecturers.All.FirstOrDefault(x => x.ProfessorName == fullname).ProfessorID;
				int realWeek = HomePage.Instance.MWeeks.DisplayWeekToRealWeek(week);
				_ = Shell.Current.GoToAsync($"{nameof(SchedulePage)}?{nameof(Schoolyear)}={schoolyear}&{nameof(Semester)}={semester}&{nameof(Week)}={realWeek}&ProfessorID={professorID}");
			}
		}
	}
}
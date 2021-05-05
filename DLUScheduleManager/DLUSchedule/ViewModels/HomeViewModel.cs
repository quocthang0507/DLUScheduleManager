using DLUSchedule.Models;
using DLUSchedule.Services;
using DLUSchedule.Utils;
using DLUSchedule.Views;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DLUSchedule.ViewModels
{
	public class HomeViewModel : BaseViewModel, INotifyPropertyChanged
	{
		private Login loginModel;
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
			get { return loginModel.Schoolyear; }
			set
			{
				loginModel.Schoolyear = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Schoolyear)));
			}
		}
		public string Semester
		{
			get { return loginModel.Semester; }
			set
			{
				loginModel.Semester = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Semester)));
			}
		}
		public string ProfessorName
		{
			get { return loginModel.ProfessorName; }
			set
			{
				loginModel.ProfessorName = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(ProfessorName)));
			}
		}
		public string ProfessorId
		{
			get { return loginModel.ProfessorId; }
			set
			{
				loginModel.ProfessorId = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(ProfessorId)));
			}
		}
		public int Week
		{
			get { return loginModel.Week; }
			set
			{
				loginModel.Week = value;
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
			loginModel = new Login();
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
			if (Common.IsNullOrWhitespace(Schoolyear, ProfessorName, Semester))
				DisplayAlertAction();
			else
			{
				ProfessorId = HomePage.Instance.MLecturers.All.FirstOrDefault(x => x.ProfessorName == ProfessorName).ProfessorID;
				if (isSaved)
					Task.Run(() => SaveLogin());
				int realWeek = HomePage.Instance.MWeeks.DisplayWeekToRealWeek(Week);
				_ = Shell.Current.GoToAsync($"{nameof(SchedulePage)}?{nameof(Schoolyear)}={Schoolyear}&{nameof(Semester)}={Semester}&{nameof(Week)}={realWeek}&ProfessorId={ProfessorId}");
			}
		}

		private async Task<bool> SaveLogin()
		{
			var database = await LoginDatabase.Instance;
			return await database.InsertOrUpdateAsync(loginModel) > 0;
		}
	}
}
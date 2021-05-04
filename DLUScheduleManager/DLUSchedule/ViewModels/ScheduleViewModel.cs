using DLUSchedule.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DLUSchedule.ViewModels
{
	[QueryProperty(nameof(Login.Schoolyear), nameof(Login.Schoolyear)),
		QueryProperty(nameof(Login.Semester), nameof(Login.Semester)),
		QueryProperty(nameof(Login.Week), nameof(Login.Week)),
		QueryProperty(nameof(Login.Lecturer.ProfessorID), nameof(Login.Lecturer.ProfessorID))]
	public class ScheduleViewModel : BaseViewModel, INotifyPropertyChanged
	{
		public Login LoginModel { get; set; }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
		public event PropertyChangedEventHandler PropertyChanged = delegate { };
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
		public string Schoolyear
		{
			get { return LoginModel.Schoolyear; }
			set
			{
				LoginModel.Schoolyear = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Schoolyear)));
			}
		}
		public string Semester
		{
			get { return LoginModel.Semester; }
			set
			{
				LoginModel.Semester = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Semester)));
			}
		}
		public string ProfessorID
		{
			get { return LoginModel.Lecturer.ProfessorID; }
			set
			{
				LoginModel.Lecturer.ProfessorID = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(ProfessorID)));
			}
		}
		public int Week
		{
			get { return LoginModel.Week; }
			set
			{
				LoginModel.Week = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Week)));
			}
		}
		public ScheduleViewModel()
		{
			LoginModel = new Login();
		}

	}
}

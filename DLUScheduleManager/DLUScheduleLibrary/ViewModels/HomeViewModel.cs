using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DLUScheduleMobile.ViewModels
{
	public class HomeViewModel : BaseViewModel, INotifyPropertyChanged
	{
		private string fullname;

		public Action DisplayBlankLoginPrompt;
		public Action DisplayInvalidLoginPrompt;
		public ICommand SubmitCommand { protected set; get; }
		public event PropertyChangedEventHandler PropertyChanged = delegate { };

		public string Fullname
		{
			get { return fullname; }
			set
			{
				fullname = value;
				PropertyChanged(this, new PropertyChangedEventArgs("Fullname"));
			}
		}

		public HomeViewModel()
		{
			SubmitCommand = new Command(OnSubmit);
			Title = "Trang chủ";
		}

		private void OnSubmit(object obj)
		{
			if (string.IsNullOrWhiteSpace(Fullname))
				DisplayBlankLoginPrompt();
			else
				DisplayInvalidLoginPrompt();
		}
	}
}
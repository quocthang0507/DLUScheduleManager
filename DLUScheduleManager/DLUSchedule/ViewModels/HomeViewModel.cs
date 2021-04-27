using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace DLUSchedule.ViewModels
{
	public class HomeViewModel : BaseViewModel, INotifyPropertyChanged
	{
		public Action DisplayAlertAction;
		public Action ReloadAction;
		public ICommand SubmitCommand { protected set; get; }
		public ICommand ReloadCommand { protected set; get; }
		public event PropertyChangedEventHandler PropertyChanged = delegate { };

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
			DisplayAlertAction();
		}
	}
}
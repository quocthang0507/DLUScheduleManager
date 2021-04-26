using DLUSchedule.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DLUSchedule.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			var model = new HomeViewModel();
			this.BindingContext = model;
			model.DisplayBlankLoginPrompt += () => DisplayAlert("Lỗi", "Không được bỏ trống ô này!", "Đồng ý");
			model.DisplayInvalidLoginPrompt += () => DisplayAlert("Lỗi", "Không tìm thấy tên giảng viên!", "Đồng ý");

			InitializeComponent();

			txtFullname.Completed += (object sender, EventArgs e) => model.SubmitCommand.Execute(null);
		}
	}
}
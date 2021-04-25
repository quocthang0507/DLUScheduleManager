using DLUScheduleMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DLUScheduleMobile.Views
{
	public partial class ItemDetailPage : ContentPage
	{
		public ItemDetailPage()
		{
			InitializeComponent();
			BindingContext = new ItemDetailViewModel();
		}
	}
}
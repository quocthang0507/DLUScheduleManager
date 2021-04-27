using DLUSchedule.Services;
using DLUSchedule.Utils;
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
	public partial class HomePage : ContentPage
	{
		private HomeViewModel model = new HomeViewModel();
		private static HomePage singleton;

		public MockWeekData mWeeks { get; protected set; }
		public MockLecturerData mLecturers { get; protected set; }

		public static HomePage Singleton
		{
			get
			{
				if (singleton == null)
					singleton = new HomePage();
				return singleton;
			}
		}

		private HomePage()
		{
			InitializeComponent();
			BindingContext = model;

			model.DisplayAlertAction += () => DisplayAlert("Lỗi", "Không được bỏ trống ô này!", "Đồng ý");
			model.ReloadAction += () => PopulateLecturersAndWeeks();

			cbxSchoolYear.SelectedIndexChanged += Combobox_SelectedIndexChanged;
			cbxSemester.SelectedIndexChanged += Combobox_SelectedIndexChanged;

			PopulateSchoolyears();
			SetCurrentSemester();
		}

		#region Events
		private void Combobox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbxSemester.SelectedItem != null && cbxSchoolYear.SelectedItem != null)
			{
				PopulateLecturersAndWeeks();
			}
		}

		#endregion

		#region Methods
		/// <summary>
		/// Tạo danh sách năm học
		/// </summary>
		private void PopulateSchoolyears()
		{
			var list = new List<string>();
			int year = 0, month = DateTime.Now.Month;
			// Thêm các năm học gần đây
			for (int i = 4; i >= 0; i--)
			{
				year = DateTime.Now.Year - i;
				string curr = $"{year - 1}-{year}";
				list.Add(curr);
			}
			if (month > 8)
				list.Add($"{year}-{year + 1}");
			cbxSchoolYear.ItemsSource = list;
			cbxSchoolYear.SelectedIndex = cbxSchoolYear.Items.Count - 1;
		}

		/// <summary>
		/// Gán học kỳ hiện tại
		/// </summary>
		private void SetCurrentSemester()
		{
			int month = DateTime.Now.Month;
			if (month <= 12 && month >= 9) // HK1
				cbxSemester.SelectedIndex = 0;
			else if (month >= 1 && month <= 6)
				cbxSemester.SelectedIndex = 1; // HK2
			else
				cbxSemester.SelectedIndex = 2; // HK3
		}

		/// <summary>
		/// Lấy danh sách tuần theo học kỳ
		/// </summary>
		/// <param name="schoolyear">VD: 2020-2021</param>
		/// <param name="semester">VD: HK01</param>
		private async Task PopulateWeeksInSemesterAsync(string schoolyear, string semester)
		{
			mWeeks = new MockWeekData(schoolyear, semester);
			if (mWeeks.Items == null)
			{
				await DisplayAlert("Lỗi", "Lỗi xuất hiện khi xử lý dữ liệu", "OK");
				return;
			}
			else cbxWeek.ItemsSource = mWeeks.Items.Select(x => x.DisPlayWeek).ToList();
		}

		/// <summary>
		/// Lấy danh sách giảng viên theo học kỳ
		/// </summary>
		/// <param name="schoolyear">VD: 2020-2021</param>
		/// <param name="semester">VD: HK01</param>
		private async Task PopulateLecturersInSemesterAsync(string schoolyear, string semester)
		{
			mLecturers = new MockLecturerData(schoolyear, semester);
			if (mLecturers.Items == null)
			{
				await DisplayAlert("Lỗi", "Lỗi xuất hiện khi xử lý dữ liệu", "OK");
				return;
			}
			cbxLecturer.ItemsSource = mLecturers.Items.Select(x => x.ProfessorName).ToList();
		}

		/// <summary>
		/// Tải lại các nội dung khi học kỳ hoặc tên giảng viên bị thay đổi
		/// </summary>
		private void PopulateLecturersAndWeeks()
		{
			PopulateLecturersInSemesterAsync(cbxSchoolYear.SelectedItem as string, cbxSemester.SelectedItem as string);
			cbxLecturer.SelectedIndex = 0;

			PopulateWeeksInSemesterAsync(cbxSchoolYear.SelectedItem as string, cbxSemester.SelectedItem as string);
			if (mWeeks.Items != null)
			{
				int numberOfWeeks = Common.GetWeekOfYear(DateTime.Now);
				var findWeek = mWeeks.Items.Where(x => x.Week == numberOfWeeks).FirstOrDefault();
				if (findWeek != null)
					cbxWeek.SelectedIndex = findWeek.DisPlayWeek - 1;
				else
					cbxWeek.SelectedIndex = 0;
			}
		}
		#endregion
	}
}
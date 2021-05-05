using DLUSchedule.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Web;

namespace DLUSchedule.Utils
{
	public class Common
	{
		/// <summary>
		/// Đổi các ký tự có dạng &#xxxx; sang ký tự Unicode
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string CharEntityToUnicode(string input)
		{
			StringBuilder output = new StringBuilder(input.Length);

			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] == '&')
				{
					int startOfEntity = i; // just for easier reading
					int endOfEntity = input.IndexOf(';', startOfEntity);
					string entity = input.Substring(startOfEntity, endOfEntity - startOfEntity);
					int unicodeNumber = (int)(HttpUtility.HtmlDecode(entity)[0]);
					output.Append("&#" + unicodeNumber + ";");
					i = endOfEntity; // continue parsing after the end of the entity
				}
				else
					output.Append(input[i]);
			}
			return output.ToString();
		}

		/// <summary>
		/// Lấy chuỗi JSON từ URL dưới dạng danh sách đối tượng
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="url"></param>
		/// <returns></returns>
		public static List<T> GetJsonsFromURL<T>(string url)
		{
			try
			{
				using (WebClient client = new WebClient())
				{
					var json = client.DownloadString(url);
					var list = JsonConvert.DeserializeObject<List<T>>(json);
					return list;
				}
			}
			catch { }
			return null;
		}

		/// <summary>
		/// Lấy mã HTML từ URL
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		public static string GetHTMLFromURL(string url)
		{
			try
			{
				using (WebClient client = new WebClient())
				{
					var data = client.DownloadData(url);
					return Encoding.UTF8.GetString(data);
				}
			}
			catch { }
			return string.Empty;
		}

		/// <summary>
		/// Lấy số tuần của thời gian cụ thể
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public static int GetWeekOfYear(DateTime dateTime)
		{
			// Gets the Calendar instance associated with a CultureInfo.
			CultureInfo cultureInfo = DLUSchedule.Properties.Resources.Culture;
			Calendar calendar = cultureInfo.Calendar;

			// Gets the DTFI properties required by GetWeekOfYear.
			CalendarWeekRule rule = cultureInfo.DateTimeFormat.CalendarWeekRule;
			DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;

			return calendar.GetWeekOfYear(dateTime, rule, firstDayOfWeek);
		}

		/// <summary>
		/// Kiểm tra kết nối internet
		/// </summary>
		/// <returns></returns>
		public static bool IsConnectedToInternet()
		{
			string host = @"https://www.google.com.vn/?gws_rd=ssl";
			bool result = false;
			Ping ping = new Ping();
			try
			{
				PingReply reply = ping.Send(host, 3000);
				if (reply.Status == IPStatus.Success)
					return true;
			}
			catch { }
			return result;
		}

		/// <summary>
		/// Kiểm tra IsNullOrWhitespace nhiều chuỗi
		/// </summary>
		/// <param name="strs"></param>
		/// <returns></returns>
		public static bool IsNullOrWhitespace(params string[] strs)
		{
			foreach (var str in strs)
			{
				if (string.IsNullOrWhiteSpace(str))
					return true;
			}
			return false;
		}

		/// <summary>
		/// Dựa vào thời gian cụ thể, trả về ngày đầu tuần
		/// </summary>
		/// <param name="dt"></param>
		/// <param name="startOfWeek"></param>
		/// <returns></returns>
		public static DateTime GetStartOfWeek(DateTime dt, DayOfWeek startOfWeek)
		{
			int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
			return dt.AddDays(-1 * diff).Date;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="year"></param>
		/// <param name="weekNum"></param>
		/// <param name="rule"></param>
		/// <returns></returns>
		public static DateTime GetFirstDayOfWeek(int year, int weekNum, DayOfWeek startOfWeek)
		{
			DateTime jan1 = new DateTime(year, 1, 1);
			int daysOffset = DayOfWeek.Monday - jan1.DayOfWeek;
			DateTime firstMonday = jan1.AddDays(daysOffset);

			var cal = Resources.Culture.Calendar;
			int firstWeek = cal.GetWeekOfYear(firstMonday, Resources.Culture.DateTimeFormat.CalendarWeekRule, startOfWeek);

			if (firstWeek <= 1)
			{
				weekNum -= 1;
			}

			DateTime result = firstMonday.AddDays(weekNum * 7);
			return result;
		}
	}
}

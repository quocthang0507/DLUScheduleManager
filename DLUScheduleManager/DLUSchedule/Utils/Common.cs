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
		/// Lấy số tuần của thời gian hiện tại
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public static int GetWeekOfYear(DateTime dateTime)
		{
			// Gets the Calendar instance associated with a CultureInfo.
			CultureInfo myCI = new CultureInfo("en-US");
			Calendar myCal = myCI.Calendar;

			// Gets the DTFI properties required by GetWeekOfYear.
			CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
			DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

			return myCal.GetWeekOfYear(dateTime, myCWR, myFirstDOW);
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
				if (!string.IsNullOrWhiteSpace(str))
					return false;
			}
			return true;
		}
	}
}

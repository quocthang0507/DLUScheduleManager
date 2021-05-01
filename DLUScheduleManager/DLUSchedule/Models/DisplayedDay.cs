namespace DLUSchedule.Models
{
	public class DisplayedDay
	{
		public string DayOfWeek { get; set; }
		public string Morning { get; set; }
		public string Afternoon { get; set; }
		public string Night { get; set; }

		public DisplayedDay(string dayOfWeek, string morning, string afternoon, string night)
		{
			DayOfWeek = dayOfWeek;
			Morning = morning;
			Afternoon = afternoon;
			Night = night;
		}

	}
}

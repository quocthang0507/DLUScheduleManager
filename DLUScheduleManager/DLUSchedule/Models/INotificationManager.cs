using System;

namespace DLUSchedule.Models
{
	public interface INotificationManager
	{
		event EventHandler NotificationReceived;
		void Initialize();
		void SendNotification(string title, string message, DateTime? notifyTime = null);
		void ReceiveNotification(string title, string message);
	}
}

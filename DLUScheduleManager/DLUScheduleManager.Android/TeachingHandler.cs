using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DLUSchedule.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLUScheduleMobile.Droid
{
	[BroadcastReceiver(Enabled = true, Label = "Local Notifications Broadcast Receiver")]
	public class TeachingHandler : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			if (intent?.Extras != null)
			{
				string title = intent.GetStringExtra(AndroidNotificationManager.TitleKey);
				string message = intent.GetStringExtra(AndroidNotificationManager.MessageKey);

				AndroidNotificationManager manager = AndroidNotificationManager.Instance ?? new AndroidNotificationManager();
				manager.Show(title, message);
			}
		}
	}
}
﻿using System.Collections.Generic;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Android.Util;
using Firebase.Messaging;

namespace Yakutia.Droid.Services
{
	[Service]
	[IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
	public class FireBaseService : FirebaseMessagingService
	{
		private const string Tag = "NKOFireBaseService";

		public override void OnMessageReceived(RemoteMessage message)
		{
			Log.Debug(Tag, "From: " + message.From);

			var body = message.GetNotification().Body;
			Log.Debug(Tag, "Notification Message Body: " + body);
			SendNotification(body, message.Data);
		}

		void SendNotification(string messageBody, IDictionary<string, string> data)
		{
			var intent = new Intent(this, typeof(MainActivity));
			intent.AddFlags(ActivityFlags.ClearTop);
			foreach (var key in data.Keys)
			{
				intent.PutExtra(key, data[key]);
			}

			var pendingIntent = PendingIntent.GetActivity(this, MainActivity.NotificationId, intent, PendingIntentFlags.OneShot);

			var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.ChannelId)
									  .SetSmallIcon(Resource.Drawable.notifications)
									  .SetContentTitle("Внимание")
									  .SetContentText(messageBody)
									  .SetAutoCancel(true)
									  .SetContentIntent(pendingIntent);

			var notificationManager = NotificationManagerCompat.From(this);
			notificationManager.Notify(MainActivity.NotificationId, notificationBuilder.Build());
		}

		public override void OnNewToken(string p0)
		{
			base.OnNewToken(p0);
			Log.Debug(Tag, "Refreshed token: " + p0);
			Debug.WriteLine(p0);
			SendRegistrationToServer(p0);
			Token = p0;
		}

		public static string Token
		{
			get;
			set;
		}

		void SendRegistrationToServer(string token)
		{
			
		}
	}
}

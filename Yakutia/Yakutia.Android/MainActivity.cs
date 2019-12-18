using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Common;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using FFImageLoading.Forms.Platform;
using Firebase;
using Firebase.Iid;

namespace Yakutia.Droid
{
    [Activity(Label = "Yakutia", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
		internal static readonly string ChannelId = "Yakutia_notification_channel";
		internal static readonly int NotificationId = 100;
		protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);
			
			CreateNotificationChannel();

			var resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);

			Log.Info("NKOFireBaseService", $"IsGooglePlayServicesAvailable code is {resultCode}");
			Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);
			CachedImageRenderer.Init(true);
			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
			LoadApplication(new App()); 
		}
		
		public static Context Instance
		{
			get;
			private set;
		}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

		private void CreateNotificationChannel()
		{
			if (Build.VERSION.SdkInt < BuildVersionCodes.O)
			{
				// Notification channels are new in API 26 (and not a part of the
				// support library). There is no need to create a notification
				// channel on older versions of Android.
				return;
			}

			var channel = new NotificationChannel(ChannelId,
												  "FCM Notifications",
												  NotificationImportance.Default)
			{

				Description = "Firebase Cloud Messages appear in this channel"
			};

			var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
			notificationManager.CreateNotificationChannel(channel);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using Firebase.CloudMessaging;
using Foundation;
using FFImageLoading.Forms.Platform;
using UIKit;
using UserNotifications;
using pushMesseges = Firebase.Core.App;

namespace Yakutia.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public void DidRefreshRegistrationToken(Messaging messaging, string fcmToken) 
                            => System.Diagnostics.Debug.WriteLine($"FCM Token: {fcmToken}");

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            pushMesseges.Configure();
            CachedImageRenderer.Init();
            LoadApplication(application: new Yakutia.App());

            if (UIDevice.CurrentDevice.CheckSystemVersion(10,0))
            {
                var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
                UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) =>
                {
                    Console.WriteLine(granted);
                });
            }

            UIApplication.SharedApplication.RegisterForRemoteNotifications();

            return base.FinishedLaunching(app, options);
        }
    }
}

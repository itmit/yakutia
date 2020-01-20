using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Firebase.InstanceID;
using Yakutia.Services;
using Xamarin.Forms;
using Yakutia.iOS.Services;

[assembly: Dependency(typeof(IOSFireBaseService))]
namespace Yakutia.iOS.Services
{
    public class IOSFireBaseService : IFireBaseService
    {
        public void DeleteInstance()
        {
            
        }

        public string GetToken(string email)
        {
            return null;
        }
    }
}
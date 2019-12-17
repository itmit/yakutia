
using System.Threading.Tasks;
using Android.Util;
using Firebase.Iid;
using Xamarin.Forms;
using Yakutia.Droid.Services;
using Yakutia.Services;
using Object = Java.Lang.Object;

[assembly: Dependency(typeof(DroidFireBaseService))]
namespace Yakutia.Droid.Services
{
	public class DroidFireBaseService : IFireBaseService
	{
		public string GetToken(string email)
		{
			var task = FirebaseInstanceId.Instance.GetInstanceId();
			
			if (task.IsSuccessful)
			{
				Token = FireBaseService.Token;
			}
			return Token;
		}

		public void DeleteInstance()
		{
			Task.Run(() =>
			{
				FirebaseInstanceId.Instance.DeleteInstanceId();
			});
		}

		public static string Token
		{
			get;
			set;
		}
	}

}

using System.Threading.Tasks;
using Realms;

namespace Yakutia
{
	public static class RealmModel
	{
		public static Realms.Realm GetInstance() => GetInstance("");

		public static Realms.Realm GetInstance(string databasePath) => GetInstance(new RealmConfiguration(databasePath));

		public static Realms.Realm GetInstance(RealmConfigurationBase config) => Realms.Realm.GetInstance(config);

		public static Task<Realms.Realm> GetInstanceAsync(RealmConfigurationBase config) => Realms.Realm.GetInstanceAsync(config);
	}
}

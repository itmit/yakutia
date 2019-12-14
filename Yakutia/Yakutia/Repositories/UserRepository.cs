using System.Collections.Generic;
using AutoMapper;
using Realms;
using Yakutia.Models;
using Yakutia.RealmObjects;

namespace Yakutia.Repositories
{
	public class UserRepository
	{
		#region Data
		#region Fields
		private readonly Realm _realm;
		private readonly IMapper _mapper;
		#endregion
		#endregion

		#region .ctor
		public UserRepository(Realm realm)
		{
			_realm = realm;
			var mapperConfiguration = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<User, UserRealmObject>();
				cfg.CreateMap<Token, TokenRealmObject>();

				cfg.CreateMap<UserRealmObject, User>();
				cfg.CreateMap<TokenRealmObject, Token>();
			});
			_mapper = mapperConfiguration.CreateMapper();
		}
		#endregion

		#region Public
		public void Add(User user)
		{
			var userRealm = _mapper.Map<UserRealmObject>(user);

			using (_realm)
			{
				using (var transaction = _realm.BeginWrite())
				{
					_realm.Add((RealmObject) userRealm, true);
					transaction.Commit();
				}
			}
		}

		public IEnumerable<User> GetAll()
		{
			using (_realm)
			{
				var users = _realm.All<UserRealmObject>();
				var userList = new List<User>();
				foreach (var user in users)
				{
					userList.Add(_mapper.Map<User>(user));
				}

				return userList;
			}
		}

		public void Remove(User user)
		{
			using (_realm)
			{
				using (var transaction = _realm.BeginWrite())
				{
					var userRealm = _realm.Find<UserRealmObject>(user.Guid.ToString());
					_realm.Remove(userRealm);
					transaction.Commit();
				}
			}
		}

		public void Update(User user)
		{
			Remove(user);
			Add(user);
		}
		#endregion
	}
}

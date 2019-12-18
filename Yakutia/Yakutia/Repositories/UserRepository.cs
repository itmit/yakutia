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
		private readonly IMapper _mapper;
		#endregion
		#endregion

		#region .ctor
		public UserRepository()
		{
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

			using (var realm = RealmModel.GetInstance())
			{
				using (var transaction = realm.BeginWrite())
				{
					realm.Add((RealmObject) userRealm, true);
					transaction.Commit();
				}
			}
		}

		public IEnumerable<User> GetAll()
		{
			using (var realm = RealmModel.GetInstance())
			{
				var users = realm.All<UserRealmObject>();
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
			using (var realm = RealmModel.GetInstance())
			{
				using (var transaction = realm.BeginWrite())
				{
					var userRealm = realm.Find<UserRealmObject>(user.Guid.ToString());
					realm.Remove(userRealm);
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

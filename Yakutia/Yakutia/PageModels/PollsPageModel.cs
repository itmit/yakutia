using System.Collections.ObjectModel;
using System.Linq;
using FreshMvvm;
using Xamarin.Essentials;
using Xamarin.Forms;
using Yakutia.Models;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	/// <summary>
	/// Представляет модель представления для страницы списка опросов.
	/// </summary>
	public class PollsPageModel : FreshBasePageModel
	{
		#region Data
		#region Fields
		private Poll _selectedPoll;
		private IPollService _service;
		#endregion
		#endregion

		#region Properties
		/// <summary>
		/// Возвращает или устанавливает список опросов.
		/// </summary>
		public ObservableCollection<Poll> Polls
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает команду при выборе опроса.
		/// </summary>
		public Command<Poll> EventSelected =>
			new Command<Poll>(poll =>
			{
				CoreMethods.PushPageModel<PollDetailPageModel>(poll);
			});

		/// <summary>
		/// Возвращает или устанавливает выбранный опрос.
		/// </summary>
		public Poll SelectedPoll
		{
			get => _selectedPoll;
			set
			{
				_selectedPoll = value;

				if (value != null)
				{
					EventSelected.Execute(value);
				}
			}
		}
		#endregion

		public string Title
		{
			get;
			set;
		} = "Все опросы.";

		#region Overrided
		/// <summary>
		/// Инициализирует модель представления.
		/// </summary>
		/// <param name="initData">Параметры модели представления.</param>
		public override void Init(object initData)
		{
			base.Init(initData);

			var repository = new UserRepository();
			var user = repository.GetAll()
								 .Single();

			_service = new PollService(user.Token);
			LoadPolls();
		}
		#endregion

		#region Private
		/// <summary>
		/// Загружает опросы.
		/// </summary>
		private async void LoadPolls()
		{
			if (Connectivity.NetworkAccess != NetworkAccess.Internet || _service == null)
			{
				return;
			}

			var polls = new ObservableCollection<Poll>(await _service.GetPolls());
			for (var i = 0; i < polls.Count; i++)
			{
				polls[i]
					.PollListNumber = i + 1;
			}

			Polls = polls;
		}
		#endregion
	}
}

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;
using Yakutia.Models;
using Yakutia.Repositories;
using Yakutia.Services;

namespace Yakutia.PageModels
{
	/// <summary>
	/// Представляет модель представления для страницы опроса. 
	/// </summary>
	public class PollDetailPageModel : FreshBasePageModel
	{
		#region Data
		#region Fields
		/// <summary>
		/// Опрос.
		/// </summary>
		private Poll _poll;

		/// <summary>
		/// Сервис для работы с опросом.
		/// </summary>
		private PollService _service;
		#endregion
		#endregion

		#region Properties
		/// <summary>
		/// Возвращает или устанавливает вопросы.
		/// </summary>
		public ObservableCollection<Question> Questions
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public ICommand PassPollCommand =>
			new FreshAwaitCommand(async (obj, tcs) =>
			{
				var repository = new UserRepository();
				var users = repository.GetAll();
				var user = users.SingleOrDefault();

				bool result = false;
				try
				{
					result = await _service.PassPull(_poll, user);
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}

				if (result)
				{
					//await CoreMethods.PushPageModel<PollResultPageModel>(_poll.Guid);
				}
				else
				{
					await Application.Current.MainPage.DisplayAlert("Уведомление", _service.Error, "Ок");
					await CoreMethods.PopPageModel();
				}

				tcs.SetResult(false);
			});
		#endregion

		#region Public
		/// <summary>
		/// Загружает вопросы.
		/// </summary>
		public async void LoadQuestions()
		{
			_poll.Questions = (await _service.GetQuestions(_poll.Guid)).ToList();
			for (var i = 0; i < _poll.Questions.Count; i++)
			{
				_poll.Questions[i]
					 .Number = i + 1;
			}
			Questions = new ObservableCollection<Question>(_poll.Questions);
		}
		#endregion

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

			if (initData is Poll poll)
			{
				_poll = poll;
				Title = _poll.Name;
				LoadQuestions();
			}
		}
		#endregion
	}
}

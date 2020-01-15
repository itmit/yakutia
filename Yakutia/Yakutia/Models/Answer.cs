using System;
using System.ComponentModel;
using System.Windows.Input;
using FreshMvvm;
using PropertyChanged;

namespace Yakutia.Models
{
	/// <summary>
	/// Представляет модель для ответов.
	/// </summary>
	public class Answer : INotifyPropertyChanged
	{
		private bool _isSelected = false;

		#region Properties
		/// <summary>
		/// Возвращает или устанавливает текст вопроса.
		/// </summary>
		public string AnswersText
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает текст другого варианта ответа.
		/// </summary>
		public bool IsVisibleOtherText
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает ид ответа.
		/// </summary>
		public Guid Guid
		{
			get;
			set;
		} = Guid.NewGuid();

		/// <summary>
		/// Возвращает или устанавливает является ли ответ "другим".
		/// </summary>
		public bool IsOther
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает выбран ли ответ.
		/// </summary>
		public bool IsSelected
		{
			get => _isSelected;
			set
			{
				if (_isSelected == value)
				{
					return;
				}

				if (!Question.Multiple && value)
				{
					foreach (var answer in Question.Answers)
					{
						if (answer.IsOther)
						{
							answer.IsVisibleOtherText = false;
						}

						answer.IsSelected = false;
						answer.NotifySelectedChanged();
					}
				}

				if (IsOther)
				{
					IsVisibleOtherText = !IsVisibleOtherText;
				}

				_isSelected = value;
				OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsSelected)));
			}
		}

		/// <summary>
		/// Уведомляет представление об изменении выбранного ответа.
		/// </summary>
		public void NotifySelectedChanged()
		{
			OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsSelected)));
		}

		/// <summary>
		/// Возвращает команду для выбора варианта ответа.
		/// </summary>
		public ICommand SelectCommand =>
			new FreshAwaitCommand((param, tcs) =>
			{
				IsSelected = !IsSelected;
				tcs.SetResult(true);
			});

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
		{
			PropertyChanged?.Invoke(this, eventArgs);
		}
		public Question Question
		{
			get;
			set;
		}

		/// <summary>
		/// Возвращает или устанавливает текст "другого" ответа, введенный пользователем.
		/// </summary>
		public string OtherText
		{
			get;
			set;
		}
		#endregion
	}
}

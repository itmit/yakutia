﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yakutia.Models;

namespace Yakutia.Services
{
	/// <summary>
	/// Представляет сервис для работы с опросами по api.
	/// </summary>
	public interface IPollService
	{
		#region Overridable
		/// <summary>
		/// Возвращает список опросов.
		/// </summary>
		/// <returns>Список опросов.</returns>
		Task<IEnumerable<Poll>> GetPolls();

		/// <summary>
		/// Возвращает список вопросов опроса.
		/// </summary>
		/// <param name="guid">Ид опроса.</param>
		/// <returns>Список вопросов.</returns>
		Task<IEnumerable<Question>> GetQuestions(Guid guid);

		/// <summary>
		/// Отправляет запрос на прохождение опроса.
		/// </summary>
		/// <param name="poll">Проходимый опрос.</param>
		/// <param name="user">Пользователь, который проходит опрос.</param>
		/// <returns>Возвращает был ли удачно пройден опрос.</returns>
		Task<bool> PassPull(Poll poll, User user);
		#endregion
	}
}

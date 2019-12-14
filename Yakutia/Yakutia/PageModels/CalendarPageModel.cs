using System;
using System.ComponentModel;
using System.Windows.Input;
using FreshMvvm;
using Yakutia.Page;

namespace Yakutia.PageModels
{
	public class CalendarPageModel :FreshBasePageModel
	{
		public bool EventCal
		{
			get;
			set;
		}

		public int Number
		{
			get;
			set;
		}

		public ICommand Press
		{
			get;
		}

		private void VisibleEvent()
		{
			EventCal = true;
			Number = 1;
		}
	}
}

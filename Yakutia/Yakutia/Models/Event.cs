using System;

namespace Yakutia.Models
{
	public class Event
	{
		public string Head
		{
			get;
			set;
		}

		public int Id
		{
			get;
			set;
		}
		public string ImageSource
		{
			get;
			set;
		}

		public string Place
		{
			get;
			set;
		}
		public Guid Uuid
		{
			get;
			set;
		}

		public string Body
		{
			get; set;
		}

		public DateTime DateStart
		{
			get;
			set;
		}
	}
}

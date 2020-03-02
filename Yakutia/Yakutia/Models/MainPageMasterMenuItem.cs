using System;

namespace Yakutia.Models
{

	public class MainPageMasterMenuItem
	{
		public MainPageMasterMenuItem()
		{
		}

		public string Title
		{
			get;
			set;
		} = string.Empty;

		public Type TargetType { get; set; }

		/// <summary>Returns a string that represents the current object.</summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString() => Title;
	}
}
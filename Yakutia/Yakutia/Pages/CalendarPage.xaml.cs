using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yakutia.Page;

namespace Yakutia.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            InitializeComponent();

			var now = DateTime.Now;
			var daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
			var week = 1;
			for (int i = 0; i < daysInMonth; i++)
			{
				var day = new DateTime(now.Year, now.Month, i + 1);
				
				var dayLabel = new Label
				{
					Text = (i + 1).ToString(),
					Style = (Style)Grid.Resources["Label"]
				};
				var dayLayout = new Frame
				{
					Content = dayLabel,
					Style = (Style)Grid.Resources["Frame"]
				};
				if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
				{
					dayLayout.BorderColor = Color.Red;
					dayLabel.TextColor = Color.Red;
				}

				Grid.Children.Add(dayLayout);

				int dayOfWeek;
				switch (day.DayOfWeek)
				{
					case DayOfWeek.Monday:
						dayOfWeek = 0;
						break;
					case DayOfWeek.Tuesday:
						dayOfWeek = 1;
						break;
					case DayOfWeek.Wednesday:
						dayOfWeek = 2;
						break;
					case DayOfWeek.Thursday:
						dayOfWeek = 3;
						break;
					case DayOfWeek.Friday:
						dayOfWeek = 4;
						break;
					case DayOfWeek.Saturday:
						dayOfWeek = 5;
						break;
					case DayOfWeek.Sunday:
						dayOfWeek = 6;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
				Grid.SetColumn(dayLayout, dayOfWeek);
				Grid.SetRow(dayLayout, week);
				if (day.DayOfWeek == DayOfWeek.Sunday)
				{
					week++;
				}
			}
		}
	}
}
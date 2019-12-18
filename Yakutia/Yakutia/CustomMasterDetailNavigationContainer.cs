using System;
using System.Linq;
using FreshMvvm;
using Xamarin.Forms;
using Yakutia.Repositories;

namespace Yakutia
{
	public class CustomMasterDetailNavigationContainer : FreshMasterDetailNavigationContainer
	{
		protected override void CreateMenuPage(string menuPageTitle, string menuIcon = null)
		{
			base.CreateMenuPage(menuPageTitle, menuIcon);

			if (Master is NavigationPage masterNavPage)
			{
				if (masterNavPage.CurrentPage is ContentPage page)
				{
					View view = page.Content;
					var stack = new StackLayout();
					stack.Children.Add(view);
					var button = new Button
					{
						Text = "Выйти",
						Visual = new VisualMarker.MaterialVisual(),
						Margin = 10
					};
					button.Clicked += ButtonOnClicked;
					stack.Children.Add(button);
					page.Content = stack;
				}
			}
		}

		private void ButtonOnClicked(object sender, EventArgs e)
		{
			if (Application.Current is App app)
			{
				var repository = new UserRepository();
				repository.Remove(repository.GetAll().Single());
				app.OpenAuthorizationPage();
			}
		}
	}
}

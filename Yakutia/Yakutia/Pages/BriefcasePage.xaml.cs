﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Yakutia.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BriefcasePage : ContentPage
    {
        public BriefcasePage()
        {
            InitializeComponent();
		}

		private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView) sender).SelectedItem = null;
		}
	}
}
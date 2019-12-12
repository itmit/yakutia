﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yakutia.ViewModels;

namespace Yakutia.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BriefcasePage : ContentPage
    {
        public BriefcasePage()
        {
            InitializeComponent();
            BindingContext = new BriefcaseViewModel();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new NewsDetailPage());
        }
    }
}
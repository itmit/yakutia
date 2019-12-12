﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yakutia.Models;
using Yakutia.ViewModels;

namespace Yakutia.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Question_answerPage : ContentPage
    {
        public Question_answerPage()
        {
            InitializeComponent();
            BindingContext = new ResponseViewModel();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Yakutia.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsViewCell : ViewCell
	{
		public NewsViewCell()
		{
			InitializeComponent();
		}
	}
}
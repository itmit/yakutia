using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yakutia.Models;

namespace Yakutia.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMasterPage : ContentPage
	{
		public ListView List
		{
			get;
		}

		public MainMasterPage()
		{
			InitializeComponent();
			List = ListView;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yakutia.PageModels;

namespace Yakutia.Views.Partials
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatInputBarView : ContentView
	{
		public ChatInputBarView()
		{
			InitializeComponent();
		}

		public void UnFocusEntry()
		{
			ChatTextInput?.Unfocus();
		}
	}
}
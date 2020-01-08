using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yakutia.PageModels;

namespace Yakutia.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompetitionsDetailPage : ContentPage
    {
        public CompetitionsDetailPage()
        {
            InitializeComponent();
        }

		private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView) sender).SelectedItem = null;
		}
	}
}
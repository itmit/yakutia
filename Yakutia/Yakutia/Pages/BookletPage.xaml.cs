using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Yakutia.Page;

namespace Yakutia.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookletPage : ContentPage
    {
        DocumentPage Page;

        public BookletPage()
        {
            InitializeComponent();
        }
    }
}
using System;
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
    public partial class CompetitionsDetailPage : ContentPage
    {
        public CompetitionsDetailPage()
        {
            InitializeComponent();
            BindingContext = new BriefcaseViewModel();
        }
    }
}
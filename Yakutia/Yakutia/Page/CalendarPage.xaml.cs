using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Yakutia.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarPage : ContentPage, INotifyPropertyChanged
    {
        private bool _eventCal;
        private int _number;
        public CalendarPage()
        {
            InitializeComponent();

            Press = new Command(VisibleEvent);
            BindingContext = this;
        }

        public bool EventCal
        {
            get => _eventCal;
            set
            {
                if (_eventCal!=value)
                {
                    _eventCal = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EventCal"));
                }
            }
        }

        public int Number 
        { 
            get => _number; 
            set
            {
                if (_number != value)
                {
                    _number = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Number"));
                }
            }
        }

        public ICommand Press
        {
            get;
        }

        private void VisibleEvent()
        {
            EventCal = true;
            Number = 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EventDetailPage());
        }
    }
}
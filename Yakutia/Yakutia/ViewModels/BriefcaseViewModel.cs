using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Yakutia.Models;

namespace Yakutia.ViewModels
{
    /// <summary>
    /// Временный класс
    /// </summary>
    public class BriefcaseViewModel
    {
        private HashSet<DataForListModel> _datas;
        private DataForListModel _data;

        public BriefcaseViewModel()
        {
            CreateList();
        }

        public DataForListModel SelectedResponse
        { 
            get => _data; 
            set
            {
                if (_data != value)
                {
                    _data = value;
                    _data.Visible = !_data.Visible;
                }
            } 
        }

        public HashSet<DataForListModel> Briefcase
        {
            get => _datas;
            set => _datas = value;
        }

        private void CreateList()
        {
            Briefcase = new HashSet<DataForListModel>();
            Briefcase.Add(new DataForListModel { Number = 1, Image = "Android.jpg" });
            Briefcase.Add(new DataForListModel { Number = 2, Image = "Apple.png" });
            Briefcase.Add(new DataForListModel { Number = 3, Image = "Windows.png" });

        }
    }
}

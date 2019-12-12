using System;
using System.Collections.Generic;
using System.Text;

namespace Yakutia.Models
{
    /// <summary>
    /// Временные данные для списков
    /// </summary>
    public class DataForListModel
    {

        public string TextAnswer 
        { 
            get; 
            set; 
        }

        public string TextResponse 
        { 
            get; 
            set; 
        }

        public int Number 
        { 
            get; 
            set; 
        }

        public string Image 
        { 
            get; 
            set; 
        }

        public bool Visible 
        { 
            get; 
            set; 
        }
    }
}

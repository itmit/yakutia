using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Yakutia.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GrantsPage : ContentPage
    {
        public GrantsPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var page = new DocumentPage
            {
                Title = "Для участников",
                Content = new StackLayout
                {
                    Margin = 20,
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Положение",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Инструкция по заполнению заявки 2020-1.pdf",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Шаблон заявки 2020-1.docx",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Рекомендации по подготовке бюджета 2020-1.pdf",
                            TextColor = Color.Black
                        }
                    }
                }
            };
            Navigation.PushAsync(page);
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            var page = new DocumentPage
            {
                Title = "Для победителей",
                Content = new StackLayout
                {
                    Margin = 20,
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Форма договора 14102019.pdf",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Требования к использованию гранта.pdf",
                            TextColor = Color.Black
                        }
                    }
                }
            };
            Navigation.PushAsync(page);
        }
    }
}
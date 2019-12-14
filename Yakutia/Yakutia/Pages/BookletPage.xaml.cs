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

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Page = new DocumentPage
            {
                Content = new StackLayout 
                { 
                    Children = 
                    { 
                        new Label
                        { 
                            Text = "•	Государсвенная пошлина за регистрацию некоммерческой организации.xls",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Государсвенная пошлина за регистрацию общественного объединения.xls",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Перечень документов для регистрации НКО.doc",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Образец заполнения заявления на регистрацию НКО Р11001.xls",
                            TextColor = Color.Black
                        },
                    },
                    Margin = 20
                }
            };
            Navigation.PushAsync(Page);
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Page = new DocumentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Государсвенная пошлина за регистрацию (реорганизацию) некоммерческой организации.xls",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Государсвенная пошлина за регистрацию (реорганизацию) общественного объединения.xls",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Перечень документов для реорганизации НКО.docx",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Образец заполнения заявления для реорганизации НКО Р12003.xls",
                            TextColor = Color.Black
                        },
                    },
                    Margin = 20
                }
            };
            Navigation.PushAsync(Page);
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Page = new DocumentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Государсвенная пошлина за регистрацию в связи с ликвидацией НКО.xls",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Государсвенная пошлина за регистрацию в связи с ликвидацией общественного объединения.xls",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Перечень документов для ликвидации НКО.docx",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Образец заполнения заявления для ликвидации 1 этап Р15001.xls",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Образец заполнения заявления для ликвидации 2 этап Р15001.xls",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Образец заполнения заявления для ликвидации 3 этап Р16001.xls",
                            TextColor = Color.Black
                        }
                    },
                    Margin = 20
                }
            };
            Navigation.PushAsync(Page);
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            Page = new DocumentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Перечень документов для внесения изменений в сведения из ЕГРЮЛ.doc",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Образец заполнения заявления для внесения изменений в сведения из ЕГРЮЛ Р14001.xls",
                            TextColor = Color.Black
                        }
                    },
                    Margin = 20
                }
            };
            Navigation.PushAsync(Page);
        }

        private void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
        {
            Page = new DocumentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Государсвенная пошлина за регистрацию изменений учредительных документов НКО.xls",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Государсвенная пошлина за регистрацию изменений учредительных документов общественного объединения.xls",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Перечень документов для внесения изменений в учредительные документы НКО.doc",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Образец заполнения заявления за регистрацию внесения изменений в учредительные документы Р13001.xlss",
                            TextColor = Color.Black
                        }
                    },
                    Margin = 20
                }
            };
            Navigation.PushAsync(Page);
        }

        private void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
        {

            Page = new DocumentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Основания для отказа в регистрации некоммерческий организации.docx",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Основания для отказа в регистрации общественного объединения.docx",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Основания для отказа в регистрации религиозной организации.docx",
                            TextColor = Color.Black
                        }
                    },
                    Margin = 20
                }
            };
            Navigation.PushAsync(Page);
        }

        private void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
        {
            Page = new DocumentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Заключение о соответствии качества оказываемых услуг.RTF",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Заявление о признании НКО ИОПУ.RTF",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Перечень документов для включения в реестр ИОПУ.docx",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Перечень органов, осуществляющих оценку качества оказываемых услуг.docx",
                            TextColor = Color.Black
                        }
                    },
                    Margin = 20
                }
            };
            Navigation.PushAsync(Page);
        }

        private void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
        {
            Page = new DocumentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Памятка об отчетности казачьих обществ.docx",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Сообщение сведений об общей численности членов казачьего общества ГРКО03.xls",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Форма отчета о деятельности НКО ОН0001.XLS",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Форма отчета о целях расходования НКО денежных средств ОН0002.XLS",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Образец отчета о соответствии п.3.1 ст. 32 ФЗ О некоммерческих организациях.doc",
                            TextColor = Color.Black
                        }
                    },
                    Margin = 20
                }
            };
            Navigation.PushAsync(Page);
        }

        private void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
        {
            Page = new DocumentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Памятка по отчетности НКО.docx",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Форма отчетности о деятельности НКО ОН0001.XLS",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Форма отчетности о целях расходования денежных средств ОН0002.XLS",

                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Образец дополнительного отчета для БЛАГОТВОРИТЕЛЬНОЙ ОО.doc",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Образец отчета для нко о соответствии п.3.1 ст. 32 ФЗ О некоммерческих организациях.doc",
                            TextColor = Color.Black
                        }
                    },
                    Margin = 20
                }
            };
            Navigation.PushAsync(Page);
        }

        private void TapGestureRecognizer_Tapped_9(object sender, EventArgs e)
        {
            Page = new DocumentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Отчет об объеме денежных средств ОН0003.XLS",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Памятка по отчетности общественных объединений.docx",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Образец дополнительного отчета для БЛАГОТВОРИТЕЛЬНЫХ ОО.doc",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Образец уведомления о продолжении деятельности.doc",
                            TextColor = Color.Black
                        }
                    },
                    Margin = 20
                }
            };
            Navigation.PushAsync(Page);
        }

        private void TapGestureRecognizer_Tapped_10(object sender, EventArgs e)
        {
            Page = new DocumentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Образец уведомления о продолжении деятельности.doc",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Отчетность профсоюзов.docx",
                            TextColor = Color.Black
                        }
                    },
                    Margin = 20
                }
            };
            Navigation.PushAsync(Page);
        }

        private void TapGestureRecognizer_Tapped_11(object sender, EventArgs e)
        {
            Page = new DocumentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Форма отчета религиозной организации ОР0001.xls",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Отчетность религиозной организации.docx",
                            TextColor = Color.Black
                        }
                    },
                    Margin = 20
                }
            };
            Navigation.PushAsync(Page);
        }

        private void TapGestureRecognizer_Tapped_12(object sender, EventArgs e)
        {
            Page = new DocumentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Способы представления отчетности.docx",
                            TextColor = Color.Black
                        }
                    },
                    Margin = 20
                }
            };
            Navigation.PushAsync(Page);
        }

        private void TapGestureRecognizer_Tapped_13(object sender, EventArgs e)
        {
            Page = new DocumentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "•	Обязанности и ответственность НКО.docx",
                            TextColor = Color.Black
                        },
                        new Label
                        {
                            Text = "•	Обязанности и ответственность общественных объединений.docx",
                            TextColor = Color.Black
                        }
                    },
                    Margin = 20
                }
            };
            Navigation.PushAsync(Page);
        }
    }
}
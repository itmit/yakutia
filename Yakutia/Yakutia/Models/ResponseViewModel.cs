using System;
using System.Collections.Generic;
using System.Text;

namespace Yakutia.Models
{
    public class ResponseViewModel
    {
        private HashSet<DataForListModel> _datas;
        public ResponseViewModel()
        {
            CreateList();
        }

        public HashSet<DataForListModel> Briefcase
        {
            get => _datas;
            set => _datas = value;
        }

        private void CreateList()
        {
            Briefcase = new HashSet<DataForListModel>();
            Briefcase.Add(new DataForListModel { TextResponse = "Что такое ТОС (территориальное общественное самоуправление)?", TextAnswer = "0" });
            Briefcase.Add(new DataForListModel { TextResponse = "Как получить консультацию по вопросам государственной регистрации некоммерческих организаций?", TextAnswer = "0" });
            Briefcase.Add(new DataForListModel { TextResponse = "Как сообщить сведения о создании филиала или представительства некоммерческой организации?", TextAnswer = "0" });
            Briefcase.Add(new DataForListModel { TextResponse = "Как изменить состав учредителей общественной организации или иной корпоративной некоммерческой организации?", TextAnswer = "0" });
            Briefcase.Add(new DataForListModel { TextResponse = "Есть ли особенности изменения адреса некоммерческой организации на другой субъект Российской Федерации?", TextAnswer = "0" });
            Briefcase.Add(new DataForListModel { TextResponse = "Где можно ознакомиться с планом проверок некоммерческих организаций?", TextAnswer = "0" });
            Briefcase.Add(new DataForListModel { TextResponse = "Как обжаловать решение территориального органа Минюста России об отказе в государственной регистрации?", TextAnswer = "0" });
            Briefcase.Add(new DataForListModel { TextResponse = "Как зарегистрировать символику некоммерческой организации?", TextAnswer = "0" });
            Briefcase.Add(new DataForListModel { TextResponse = "Какой порядок создания общероссийского общественного объединения?", TextAnswer = "0" });
            Briefcase.Add(new DataForListModel { TextResponse = "Какие документы должны быть представлены в Минюст России для его регистрации?", TextAnswer = "0" });
            Briefcase.Add(new DataForListModel { TextResponse = "Какую отчетность общественная организация или общественное движение обязаны представлять в Минюст России (его территориальный орган)?", TextAnswer = "0" });
            Briefcase.Add(new DataForListModel { TextResponse = "Как создается и регистрируется политическая партия?", TextAnswer = "0" });
            Briefcase.Add(new DataForListModel { TextResponse = "Куда представлять документы для государственной регистрации религиозной организации?", TextAnswer = "0" });
            Briefcase.Add(new DataForListModel { TextResponse = "Куда оплачивать государственную пошлину за государственную регистрацию религиозной организации?", TextAnswer = "0" });
            Briefcase.Add(new DataForListModel { TextResponse = "Какие обязанности по предоставлению отчетности установлены для казачьих обществ?", TextAnswer = "0" });
        }

    }
}

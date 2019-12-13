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
            Briefcase.Add(new DataForListModel { TextResponse = "Что такое ТОС (территориальное общественное самоуправление)?", TextAnswer = "Ответ 1" });
            Briefcase.Add(new DataForListModel { TextResponse = "Как получить консультацию по вопросам государственной регистрации некоммерческих организаций?", TextAnswer = "Ответ 2" });
            Briefcase.Add(new DataForListModel { TextResponse = "Как сообщить сведения о создании филиала или представительства некоммерческой организации?", TextAnswer = "Ответ 3" });
            Briefcase.Add(new DataForListModel { TextResponse = "Как изменить состав учредителей общественной организации или иной корпоративной некоммерческой организации?", TextAnswer = "Ответ 4" });
            Briefcase.Add(new DataForListModel { TextResponse = "Есть ли особенности изменения адреса некоммерческой организации на другой субъект Российской Федерации?", TextAnswer = "Ответ 5" });
            Briefcase.Add(new DataForListModel { TextResponse = "Где можно ознакомиться с планом проверок некоммерческих организаций?", TextAnswer = "Ответ 6" });
            Briefcase.Add(new DataForListModel { TextResponse = "Как обжаловать решение территориального органа Минюста России об отказе в государственной регистрации?", TextAnswer = "Ответ 7" });
            Briefcase.Add(new DataForListModel { TextResponse = "Как зарегистрировать символику некоммерческой организации?", TextAnswer = "Ответ 8" });
            Briefcase.Add(new DataForListModel { TextResponse = "Какой порядок создания общероссийского общественного объединения?", TextAnswer = "Ответ 9" });
            Briefcase.Add(new DataForListModel { TextResponse = "Какие документы должны быть представлены в Минюст России для его регистрации?", TextAnswer = "Ответ 10" });
            Briefcase.Add(new DataForListModel { TextResponse = "Какую отчетность общественная организация или общественное движение обязаны представлять в Минюст России (его территориальный орган)?", TextAnswer = "Ответ 11" });
            Briefcase.Add(new DataForListModel { TextResponse = "Как создается и регистрируется политическая партия?", TextAnswer = "Ответ 12" });
            Briefcase.Add(new DataForListModel { TextResponse = "Куда представлять документы для государственной регистрации религиозной организации?", TextAnswer = "Ответ 13" });
            Briefcase.Add(new DataForListModel { TextResponse = "Куда оплачивать государственную пошлину за государственную регистрацию религиозной организации?", TextAnswer = "Ответ 14" });
            Briefcase.Add(new DataForListModel { TextResponse = "Какие обязанности по предоставлению отчетности установлены для казачьих обществ?", TextAnswer = "Ответ 15" });
        }

    }
}

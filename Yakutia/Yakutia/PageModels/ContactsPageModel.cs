using System.Collections.ObjectModel;
using FreshMvvm;
using Yakutia.Models;

namespace Yakutia.PageModels
{
	public class ContactsPageModel :FreshBasePageModel
	{
		public override void Init(object initData)
		{
			base.Init(initData);

			Contacts = new ObservableCollection<Contact>
			{
				new Contact
				{
					NameResourceCenter = "Ассоциация – ресурсный центр содействия развитию некоммерческих организаций «Ассоциация консультантов, финансистов и аудиторов»",
					HeadDepartment = "Гурьева Александра Иннокентьевна",
					AddressAndContact = "г. Якутск, пр. Ленина, д.4/2,  оф.106,\r\n\r\n8(4112)32-53-28"
				},
				new Contact
				{
					NameResourceCenter = "Общественное движение – Союз женских организаций Республики Саха (Якутия)",
					HeadDepartment = "Андреева Анжелика Егоровна",
					AddressAndContact = "г. Якутск, ул. Курашова, д.24, офис 405\r\n\r\n89142338008"
				},
				new Contact
				{
					NameResourceCenter = "Якутская региональная общественная организация по защите семьи, материнства и детства «Милосердие»",
					HeadDepartment = "Тупицына Анжелика Анатольевна",
					AddressAndContact = "г. Якутск, ул. Кирова, д.8\r\n\r\n89248693243"
				},
				new Contact
				{
					NameResourceCenter = "Некоммерческая организация (фонд) «Семья для ребенка»",
					HeadDepartment = "Вешникова Ольга Анатольевна",
					AddressAndContact = "г. Якутск, ул. Курашова, д.24, офис,702 А,В\r\n\r\n89142759941"
				},
				new Contact
				{
					NameResourceCenter = "Региональное общественное движение «Ресурсный центр социальных технологий Республики Саха (Якутия)»",
					HeadDepartment = "Гаврильева Нарыяна Николаевна",
					AddressAndContact = "г. Якутск, пр. Ленина,д.46\r\n\r\n89142204757"
				},
				new Contact
				{
					NameResourceCenter = "Ассоциация развития гражданских инициатив «Женщины автолюбители Якутии»",
					HeadDepartment = "Баишева Лена Матвеевна",
					AddressAndContact = "г. Якутск, ул.Ломоносова, 42/1, кв.40\r\n\r\n89246622044"
				},
				new Contact
				{
					NameResourceCenter = "Общественная организация «Центр экологического просвещения Республики Саха (Якутия) «Эйгэ» («Окружающая среда»)",
					HeadDepartment = "Дмитриева Валентина Иннокентьевна",
					AddressAndContact = "г. Якутск, ул. Кулаковского, д.12\r\n\r\n8(4112)49-69-44"
				},
				new Contact
				{
					NameResourceCenter = "Ресурсный центр Целевого Фонда будущих поколений",
					HeadDepartment = "Попова Сардаанаа Васильевна",
					AddressAndContact = "г. Якутск, ул. Курашова, 24, офис 702, 703, 703Б\r\n\r\n8(4112)40-58-83"
				},
				new Contact
				{
					NameResourceCenter = "Отдел по взаимодействию с институтами гражданского общества Министерства по делам молодежи и социальным коммуникациям Республики Саха (Якутия)",
					HeadDepartment = "Петрова Мария Викторовна",
					AddressAndContact = "г. Якутск, пр. Ленина, д.30, каб. 414\r\n\r\n8(4112)507-123"
				}
			};
		}

		public ObservableCollection<Contact> Contacts
		{
			get;
			set;
		}
	}
}

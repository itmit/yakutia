using System.Collections.Generic;
using System.Collections.ObjectModel;
using FreshMvvm;
using Yakutia.Models;

namespace Yakutia.PageModels
{
	public class QuestionAnswerPageModel : FreshBasePageModel
	{
		private ObservableCollection<DataForListModel> _datas;

		public ObservableCollection<DataForListModel> Briefcase
		{
			get => _datas;
			set => _datas = value;
		}

		public override void Init(object initData)
		{
			base.Init(initData);
			CreateList();
		}

		private void CreateList()
		{
			Briefcase = new ObservableCollection<DataForListModel>
			{
				new DataForListModel
				{
					TextResponse = "Кто может принять участие в конкурсе Фонда Президентских грантов?",
					TextAnswer = Properties.QA.WhoCanTakePartInTheContestOfThePresidentialGrantsFund
				},
				new DataForListModel
				{
					TextResponse = "Какие организации не могут принимать участие в конкурсе Фонда\r\nПрезидентских грантов?",
					TextAnswer = Properties.QA.WhichOrganizationsCannot_participateInTheFundsCompetitionPresidentialGrants
				},
				new DataForListModel
				{
					TextResponse = "Как получить консультацию по вопросам государственной регистрации\r\nнекоммерческих организаций?",
					TextAnswer = Properties.QA.HowToGetAdviceOnStateRegistrationOfNonProfitOrganizations
				},
				new DataForListModel
				{
					TextResponse = "Как сообщить сведения о создании филиала или представительства\r\nнекоммерческой организации?",
					TextAnswer = Properties.QA.HowReportEstablishmentBranchOrRepresentativeOfficeNonProfitOrganization
				},
				new DataForListModel
				{
					TextResponse = "Как изменить состав учредителей общественной организации или иной\r\nкорпоративной некоммерческой организации?",
					TextAnswer = Properties.QA.HowChangeCompositionFoundersPPublicOrganizationOrOtherCorporateNonProfitOrganization
				},
				new DataForListModel
				{
					TextResponse = "Есть ли особенности изменения адреса некоммерческой организации на\r\nдругой субъект Российской Федерации?",
					TextAnswer = Properties.QA.String1
				},
				new DataForListModel
				{
					TextResponse = "Где можно ознакомиться с планом проверок некоммерческих организаций?",
					TextAnswer = Properties.QA.String2
				},
				new DataForListModel
				{
					TextResponse = "Как обжаловать решение территориального органа Минюста России об\r\nотказе в государственной регистрации?",
					TextAnswer = Properties.QA.String3
				},
				new DataForListModel
				{
					TextResponse = "Как зарегистрировать символику некоммерческой организации?",
					TextAnswer = Properties.QA.String4
				},
				new DataForListModel
				{
					TextResponse = "Какой порядок создания общероссийского общественного объединения?",
					TextAnswer = Properties.QA.String5
				},
				new DataForListModel
				{
					TextResponse = "Какой орган осуществляет оценку качества оказания общественно полезных\r\nуслуг социально ориентированными некоммерческими организациями?",
					TextAnswer = Properties.QA.String6
				},
				new DataForListModel
				{
					TextResponse = "Какую отчетность общественная организация или общественное движение\r\nобязаны представлять в Минюст России (его территориальный орган)?",
					TextAnswer = Properties.QA.String7
				},
				new DataForListModel
				{
					TextResponse = "В банке требуют выписку из реестра филиалов и представительств\r\nмеждународных организаций и иностранных некоммерческих неправительственных\r\nорганизаций по состоянию на сегодняшний день. Как можно ее получить?",
					TextAnswer = Properties.QA.String8
				},
				new DataForListModel
				{
					TextResponse = "Как и где получить информацию о некоммерческой организации?",
					TextAnswer = Properties.QA.String9
				}
			};
		}

	}
}

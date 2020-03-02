using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FreshMvvm;
using Xamarin.Forms;
using Yakutia.Models;
using Yakutia.Repositories;

namespace Yakutia.PageModels
{
	public class MainMasterPageModel : FreshBasePageModel
	{
		private FreshAwaitCommand _exitCommand;

		public FreshAwaitCommand ExitCommand
		{
			get
			{
				_exitCommand = _exitCommand ?? new FreshAwaitCommand(Execute);

				return _exitCommand;
			}
		}

		public ObservableCollection<MainPageMasterMenuItem> Pages
		{
			get;
			private set;
		}

		public override void Init(object initData)
		{
			base.Init(initData);
			Pages = new ObservableCollection<MainPageMasterMenuItem>
			{
				new MainPageMasterMenuItem
				{
					TargetType = typeof(NewsPageModel),
					Title = "Новости"
				},
				new MainPageMasterMenuItem
				{
					TargetType = typeof(BookletPageModel),
					Title = "Правовые памятки"
				},
				new MainPageMasterMenuItem
				{
					TargetType = typeof(QuestionAnswerPageModel),
					Title = "Вопросы—Ответы"
				},
				new MainPageMasterMenuItem
				{
					TargetType = typeof(CompetitionsPageModel),
					Title = "Конкурсы"
				},
				new MainPageMasterMenuItem
				{
					TargetType = typeof(BriefcasePageModel),
					Title = "Успешные кейсы/практики"
				},
				new MainPageMasterMenuItem
				{
					TargetType = typeof(CalendarPageModel),
					Title = "Календарь событий"
				},
				new MainPageMasterMenuItem
				{
					TargetType = typeof(PollsPageModel),
					Title = "Онлайн голосование"
				},
				new MainPageMasterMenuItem
				{
					TargetType = typeof(ChatPageModel),
					Title = "Чат"
				},
				new MainPageMasterMenuItem
				{
					TargetType = typeof(ContactsPageModel),
					Title = "Контакты"
				},
				new MainPageMasterMenuItem
				{
					TargetType = typeof(GrantsPageModel),
					Title = "Президентские гранты"
				},
				new MainPageMasterMenuItem
				{
					TargetType = typeof(ApplicationPageModel),
					Title = "О приложении"
				}
			};
		}

		private void Execute(TaskCompletionSource<bool> obj)
		{
			if (Application.Current is App app)
			{
				var repository = new UserRepository();
				repository.Remove(repository.GetAll().Single());
				app.OpenAuthorizationPage();
			}

			obj.SetResult(true);
		}
	}
}

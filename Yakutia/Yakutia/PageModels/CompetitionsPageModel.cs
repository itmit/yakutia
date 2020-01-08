using System.Windows.Input;
using FreshMvvm;

namespace Yakutia.PageModels
{
	public class CompetitionsPageModel :FreshBasePageModel
	{
		public ICommand OpenUpFederalContests => new FreshAwaitCommand((obj, tcs) =>
		{
			CoreMethods.PushPageModel<CompetitionsDetailPageModel>("федеральный");

			tcs.SetResult(true);
		});
		
		public ICommand OpenUpRegionalContests => new FreshAwaitCommand((obj, tcs) =>
		{
			CoreMethods.PushPageModel<CompetitionsDetailPageModel>("региональный");

			tcs.SetResult(true);
		});
	}
}

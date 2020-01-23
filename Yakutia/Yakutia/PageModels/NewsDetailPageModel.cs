using FreshMvvm;
using Xamarin.Forms;
using Yakutia.Models;

namespace Yakutia.PageModels
{
	class NewsDetailPageModel : FreshBasePageModel
	{
		
		public BaseInfoBlock News
		{
			get; 
			private set;
		}

		public override void Init(object initData)
		{
			base.Init(initData);
			if (initData is BaseInfoBlock news)
			{
				News = news;
				HtmlSource = new HtmlWebViewSource
				{
					Html = "<html><body>" + news.Text + "</body></html>"
				};
			}
		}

		public HtmlWebViewSource HtmlSource
		{
			get;
			private set;
		}
	}
}

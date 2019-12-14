using System;
using System.Collections.Generic;
using System.Text;
using FreshMvvm;
using Xamarin.Forms;
using Yakutia.Models;

namespace Yakutia.PageModels
{
	class NewsDetailPageModel : FreshBasePageModel
	{
		public News News
		{
			get; 
			private set;
		}

		public override void Init(object initData)
		{
			base.Init(initData);
			if (initData is News news)
			{
				News = news;
				HtmlSource = new HtmlWebViewSource
				{
					Html = news.Text
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

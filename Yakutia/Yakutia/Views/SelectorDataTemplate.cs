using Xamarin.Forms;
using Yakutia.Models;

namespace Yakutia.Views
{
	public class SelectorDataTemplate : DataTemplateSelector
	{
		private readonly DataTemplate _textInDataTemplate;
		private readonly DataTemplate _textOutDataTemplate;

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			var messageVm = item as Message;
			if (messageVm == null)
				return null;

			return messageVm.IsTextOut ? _textOutDataTemplate : _textInDataTemplate;
		}


		public SelectorDataTemplate()
		{
			this._textInDataTemplate = new DataTemplate(typeof(TextInViewCell));
			this._textOutDataTemplate = new DataTemplate(typeof(TextOutViewCell));
		}

	}
}

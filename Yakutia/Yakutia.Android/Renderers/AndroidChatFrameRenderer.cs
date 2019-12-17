using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Yakutia.Controls;
using Yakutia.Droid.Renderers;

[assembly: ExportRenderer(typeof(ChatFrame), typeof(AndroidChatFrameRenderer))]

namespace Yakutia.Droid.Renderers
{
    public class AndroidChatFrameRenderer : VisualElementRenderer<Frame>
    {
        public AndroidChatFrameRenderer(Context context) : base(context)
        {
        }

		protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
		{
			base.OnElementChanged(e);
			SetBackgroundResource(Resource.Drawable.chatframe);
		}
	}
}
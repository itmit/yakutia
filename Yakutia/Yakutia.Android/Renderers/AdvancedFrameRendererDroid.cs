using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Yakutia.Controls;
using Yakutia.Droid.Renderers;

[assembly: ExportRenderer(typeof(AdvancedFrame), typeof(AndroidOutFrame))]

namespace Yakutia.Droid.Renderers
{
    public class AndroidOutFrame : VisualElementRenderer<Frame>
    {
        public AndroidOutFrame(Context context)
			:base(context)
		{
        }

		protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
		{
			base.OnElementChanged(e);

			SetBackgroundResource(Resource.Drawable.outframe);
		}
	}
}
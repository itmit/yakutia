using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Yakutia.Controls;
using Yakutia.Droid.Renderers;

[assembly: ExportRenderer(typeof(Inframe), typeof(AndroidInFrame))]

namespace Yakutia.Droid.Renderers
{
    public class AndroidInFrame : VisualElementRenderer<Frame>
    {
        public AndroidInFrame(Context context) :base(context)
        {
        }

		protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
		{
			base.OnElementChanged(e);

			SetBackgroundResource(Resource.Drawable.inframe);
		}
	}
}
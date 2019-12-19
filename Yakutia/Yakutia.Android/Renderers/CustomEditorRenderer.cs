
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Yakutia.Controls;
using Yakutia.Droid.Renderers;

[assembly: ExportRenderer(typeof(ExtendedEditorControl), typeof(CustomEditorRenderer))]
namespace Yakutia.Droid.Renderers
{
	public class CustomEditorRenderer : EditorRenderer
	{
		private bool _initial = true;
		private Drawable _originalBackground;

		public CustomEditorRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				if (_initial)
				{
					_originalBackground = Control.Background;
					_initial = false;
				}
				Control.SetMaxLines(5);

			}

			if (e.NewElement != null)
			{
				var customControl = (ExtendedEditorControl)Element;
				if (customControl.HasRoundedCorner)
				{
					ApplyBorder();
				}

				if (!string.IsNullOrEmpty(customControl.Placeholder))
				{
					if (Control != null)
					{
						Control.Hint = customControl.Placeholder;
						Control.SetHintTextColor(customControl.PlaceholderColor.ToAndroid());
					}
				}
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			var customControl = (ExtendedEditorControl)Element;

			if (Editor.PlaceholderProperty.PropertyName == e.PropertyName)
			{
				Control.Hint = customControl.Placeholder;

			}
			else if (Editor.PlaceholderColorProperty.PropertyName == e.PropertyName)
			{

				Control.SetHintTextColor(customControl.PlaceholderColor.ToAndroid());

			}
			else if (ExtendedEditorControl.HasRoundedCornerProperty.PropertyName == e.PropertyName)
			{
				if (customControl.HasRoundedCorner)
				{
					ApplyBorder();

				}
				else
				{
					Control.Background = _originalBackground;
				}
			}
		}

		private void ApplyBorder()
		{
			GradientDrawable gd = new GradientDrawable();
			gd.SetCornerRadius(10);
			gd.SetStroke(2, Color.Black.ToAndroid());
			Control.Background = gd;
		}
	}
}

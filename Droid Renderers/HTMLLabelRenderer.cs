using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget; 
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]
namespace CodeBeaulieu.Droid
{  
	public class HtmlLabelRenderer : LabelRenderer
	{ 
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			Control?.SetText(Html.FromHtml(Element.Text), TextView.BufferType.Spannable);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == Label.TextProperty.PropertyName)
			{
				Control?.SetText(Html.FromHtml(Element.Text), TextView.BufferType.Spannable);
			}
		}
	} 
}

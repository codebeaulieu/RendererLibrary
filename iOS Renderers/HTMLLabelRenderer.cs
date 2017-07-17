using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Foundation; 
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

// source: https://forums.xamarin.com/discussion/56484/need-to-put-html-into-a-label

[assembly: ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]
namespace CodeBeaulieu.iOS
{  
	public class HtmlLabelRenderer : LabelRenderer
	{

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text))
			{
				var attr = new NSAttributedStringDocumentAttributes();
				var nsError = new NSError();
				attr.DocumentType = NSDocumentType.HTML;

				UIKit.UIFont font = Control.Font;
				string fontName = font.Name;
				System.nfloat fontSize = font.PointSize;
				string htmlContents = "<span style=\"font-family: '" + fontName + "'; font-size: " + fontSize + "\">" + Element.Text + "</span>";
				var myHtmlData = NSData.FromString(htmlContents, NSStringEncoding.Unicode);
				Control.Lines = 0;
				Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == Label.TextProperty.PropertyName)
			{
				if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text))
				{
					var attr = new NSAttributedStringDocumentAttributes();
					var nsError = new NSError();
					attr.DocumentType = NSDocumentType.HTML;

					UIKit.UIFont font = Control.Font;
					string fontName = font.Name;
					System.nfloat fontSize = font.PointSize;
					string htmlContents = "<span style=\"font-family: '" + fontName + "'; font-size: " + fontSize + "\">" + Element.Text + "</span>";
					var myHtmlData = NSData.FromString(htmlContents, NSStringEncoding.Unicode);
					Control.Lines = 0;
					Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);
				}
			}
		}
	}
}

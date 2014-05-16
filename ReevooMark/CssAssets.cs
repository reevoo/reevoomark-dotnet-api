using System;
using System.Web.UI;
using System.IO;

namespace ReevooMark
{
	public class CssAssets: System.Web.UI.UserControl
	{
	
		protected override void Render(HtmlTextWriter writer)
		{	
			string relValue = "stylesheet";
			string urlValue = "//mark.reevoo.com/stylesheets/reevoomark/embedded_reviews.css";
			string typeValue = "text/css";

			writer.AddAttribute(HtmlTextWriterAttribute.Rel, relValue);
			writer.AddAttribute(HtmlTextWriterAttribute.Href, urlValue);
			writer.AddAttribute(HtmlTextWriterAttribute.Type, typeValue);
			writer.RenderBeginTag (HtmlTextWriterTag.Link);
			writer.RenderEndTag();
		}

	}
}


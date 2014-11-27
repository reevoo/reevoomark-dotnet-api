using System;
using System.Web.UI;
using System.IO;

namespace ReevooMark
{
    public class CssAssets: System.Web.UI.UserControl
    {
        protected override void Render (HtmlTextWriter writer)
        {
            try {
				string relValue = "stylesheet";
				string urlValue = Config.BaseUriAssets() + "stylesheets/reevoomark/embedded_reviews.css";
                string typeValue = "text/css";

                writer.AddAttribute (HtmlTextWriterAttribute.Rel, relValue);
                writer.AddAttribute (HtmlTextWriterAttribute.Href, urlValue);
                writer.AddAttribute (HtmlTextWriterAttribute.Type, typeValue);
                writer.RenderBeginTag (HtmlTextWriterTag.Link);
                writer.RenderEndTag ();
            } catch (Exception e_) {
                throw new ReevooException (e_);
            }

        }
    }
}


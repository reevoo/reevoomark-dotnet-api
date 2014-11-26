using System;
using System.Web.UI;
using System.ComponentModel;
using System.Web.Configuration;

namespace ReevooMark
{
    /// <summary>
    /// A <see cref="System.Web.UI.UserControl"/> for showing in-line reviews for Reevoo products
    /// </summary>
    public class Mark : AbstractReevooTag
    {
        public Mark()
        {
            this.BaseUri = @"http://mark.reevoo.com/reevoomark/en-GB/embeddable_reviews";
        }

        protected override void OnInit (EventArgs e)
        {
            base.OnInit (e);
            if (String.IsNullOrEmpty (Sku)) {
                Trace.Write ("Sku property is empty; returning nothing");
            }

        }
            
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            String _content;
            try
            {
				_content = new ReevooClient().ObtainReevooMarkData(BuildParams(), BaseUri).Content;
            }
            catch (ReevooException re_)
            {
                //We wrap all exceptions with a ReevooException. Log the error & return the empty string.
                Trace.Write(re_.Message);
                _content = String.Empty;
            }
            writer.Write(_content);
        }

    }
}
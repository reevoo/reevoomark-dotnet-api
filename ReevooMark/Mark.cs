using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReevooMark
{
    /// <summary>
    /// A <see cref="System.Web.UI.UserControl"/> for showing in-line reviews for Reevoo products
    /// </summary>
    public class Mark : System.Web.UI.UserControl
    {
        /// <summary>
        /// A sensible default for the base URI; so this property is optional
        /// </summary>
        private string _baseUri = @"http://mark.reevoo.com/reevoomark/en-GB/embeddable_reviews";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            String _content;
            try
            {
                _content = new ReevooClient().ObtainReevooMarkData(TkRef, SKU, BaseUri).Content;
            }
            catch (ReevooException re_)
            {
                //We wrap all exceptions with a ReevooException. Log the error & return the empty string.
                Trace.Write(re_.Message);
                _content = String.Empty;
            }
            writer.Write(_content);
        }

        public String SKU { get; set; }
        public String TkRef { get; set; }

        //provide a sensible default for BaseUri, seeing as we know it.
        public String BaseUri
        {
            get { return _baseUri; }
            set { _baseUri = value; }
        }
    }
}

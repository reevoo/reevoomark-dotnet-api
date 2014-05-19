using System;
using System.Web.UI;
using System.ComponentModel;

namespace ReevooMark
{
	/// <summary>
	/// Base abstact class <see cref="System.Web.UI.UserControl"/> for showing in-line product and customer experience reviews for Reevoo products and retailers.
	/// </summary>
	[ParseChildren(true, "Text")]
	public abstract class AbstractReevooTag : System.Web.UI.UserControl
	{
		/// <summary>
		/// A sensible default for the base URI; so this property is optional
		/// </summary>
		protected string _baseUri;

		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{	
			writer.Write(this.GetContent());
		}

		public String GetContent()
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
			return _content;
		}

		public String SKU { get; set; }
		public String TkRef { get; set; }
		[DefaultValue("")]
		public String Text { get; set; }

		//provide a sensible default for BaseUri, seeing as we know it.
		public String BaseUri
		{
			get { return _baseUri; }
			set { _baseUri = value; }
		}
	}

}


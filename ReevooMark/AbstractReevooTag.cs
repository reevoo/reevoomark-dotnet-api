﻿using System;
using System.Web.UI;
using System.ComponentModel;
using System.Web.Configuration;

namespace ReevooMark
{
	/// <summary>
	/// Base abstact class <see cref="System.Web.UI.UserControl"/> for showing Reevoomark products.
	/// </summary>
	[ParseChildren(true, "Text")]
	public abstract class AbstractReevooTag : System.Web.UI.UserControl
	{
		protected string _baseUri;

		protected override void OnInit(EventArgs e)
		{
			if (String.IsNullOrEmpty (TRKREF) && String.IsNullOrEmpty (WebConfigurationManager.AppSettings ["TRKREF"])) 
			{
				Trace.Write("TRKREF property is empty; returning nothing");
			}

			else if (String.IsNullOrEmpty(TRKREF))
			{
				this.TRKREF = WebConfigurationManager.AppSettings["TRKREF"]; 
			}

		}

		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{	
			writer.Write(this.GetContent());
		}

		public String GetContent()
		{
			String _content;
			try
			{
				_content = new ReevooClient().ObtainReevooMarkData(TRKREF, SKU, BaseUri).Content;
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
		public String TRKREF { get; set; }
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


using System;
using ReevooMark;
using System.Web.UI;

namespace ReevooMark
{
	public class PurchaseTrackingEvent:AbstractReevooTag
	{
		const String PURCHASE_TRACKING_SCRIPT =  
			"if (typeof afterReevooMarkLoaded === 'undefined') {{" +
					"var afterReevooMarkLoaded = [];" +
			"}};" +
				"afterReevooMarkLoaded.push(" +
			"function(){{" +
				"ReevooApi.load(\"{0}\", function(retailer){{" +
						"retailer.track_purchase(\"{1}\".split(/[ ,]+/), \"{2}\");" +
					"}});" +
				"}}" +
			");";


		protected String _skus;
		protected String _value;

		public string Skus {
			get { return _skus; }
			set { _skus = value; }
		}

		public string Value {
			get { return _value; }
			set { _value = value; }
		}

		protected override void Render (HtmlTextWriter writer)
		{    
			try {
				string input = String.Format (PURCHASE_TRACKING_SCRIPT, Trkref, Skus, Value);
				writer.AddAttribute (HtmlTextWriterAttribute.Type, "text/javascript");
				writer.RenderBeginTag (HtmlTextWriterTag.Script);
				writer.Write (input);
				writer.RenderEndTag ();
			} catch (Exception e_) {
				throw new ReevooException (e_);
			}
		}
	}
}


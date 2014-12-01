using System;
using ReevooMark;
using System.Web.UI;

namespace ReevooMark
{
	public class PropensityToBuyTrackingEvent:AbstractReevooTag
	{
		const String PROPENSITY_TRACKING_SCRIPT =  
			"if (typeof afterReevooMarkLoaded === 'undefined') {{" +
			"var afterReevooMarkLoaded = [];" +
			"}};" +
			"afterReevooMarkLoaded.push(" +
			"function(){{" +
			"ReevooApi.load(\"{0}\", function(retailer){{" +
			"retailer.Tracking.ga_track_event(\"Propensity to buy\", \"{1}\", \"{2}\");retailer.track_exit();" +
			"}});" +
			"}}" +
			");";
			
		protected String _action;

		public string Action {
			get { return _action; }
			set { _action = value; }
		}

		protected override void Render (HtmlTextWriter writer)
		{    
			try {
				string item = Sku;
				if (String.IsNullOrEmpty (item)) {
					item = "Global CTA";
				}
				string input = String.Format (PROPENSITY_TRACKING_SCRIPT, Trkref, Action, item);
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
	
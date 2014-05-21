using System;
using ReevooMark;
using System.Web.UI;

namespace ReevooMark
{
	public class JavascriptAssets:AbstractReevooTag
	{

		const String SINGLE_TRKREF_MARKLOADER = "(function () {{var script = document.createElement('script'); " +
															  "script.type = 'text/javascript'; " +
															  "script.src = '//cdn.mark.reevoo.com/assets/reevoo_mark.js';" +
															  "var s = document.getElementById('reevoomark-loader'); " +
															  "s.parentNode.insertBefore(script, s); }})();" +
															  "afterReevooMarkLoaded = [];" +
															  "afterReevooMarkLoaded.push(function () {{ReevooApi.load(\"{0}\", function (retailer) {{window.ReevooMark=retailer;retailer.init_badges();retailer.init_reevoo_reputation_badges();}});}});";

		const String MULTI_TRKREF_MARKLOADER = "(function () {{var script = document.createElement('script');" +
															 "script.type = 'text/javascript';" +
															 "script.src = '//cdn.mark.reevoo.com/assets/reevoo_mark.js';" +
															 "var s = document.getElementById('reevoomark-loader');" +
															 "s.parentNode.insertBefore(script, s);" +
			"}})();" +
			"afterReevooMarkLoaded = [function () {{ReevooApi.each(\"{0}\".split(/[ ,]+/), function (retailer) {{window.ReevooMark=retailer; retailer.init_badges();retailer.init_reevoo_reputation_badges();}});}}];";
			

		protected override void Render(HtmlTextWriter writer)
		{	
			try{
				string idValue = "reevoomark-loader";
				string typeValue = "text/javascript";
		

				string js_container = GetMarkLoaderScript();
				string input = String.Format(js_container, TRKREF);
					
				writer.AddAttribute (HtmlTextWriterAttribute.Id, idValue);
				writer.AddAttribute (HtmlTextWriterAttribute.Type, typeValue);
				writer.RenderBeginTag (HtmlTextWriterTag.Script);
				writer.Write(input);
				writer.RenderEndTag();
			}
			catch (Exception e_)
			{
				throw new ReevooException(e_);
			}
		}


		private String GetMarkLoaderScript()
		{
			if (TRKREF.Contains (","))
				return MULTI_TRKREF_MARKLOADER;
			else
				return SINGLE_TRKREF_MARKLOADER;
		} 
	}
}


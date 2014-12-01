using System;
using ReevooMark;
using System.Web.UI;

namespace ReevooMark
{
    public class JavascriptAssets:AbstractReevooTag
    {
        const String MARKLOADER_SCRIPT = 
			"(function () {{" +
				"var script = document.createElement('script');" +
				"script.type = 'text/javascript';" +
			"script.src = '//cdn.mark.reevoo.com/assets/reevoo_mark.js';" +
				"var s = document.getElementById('reevoomark-loader');" +
				"s.parentNode.insertBefore(script, s);" +
			"}})();" +
			"if (typeof afterReevooMarkLoaded === 'undefined') {{" +
				"var afterReevooMarkLoaded = [];" +
			"}}" +
			"afterReevooMarkLoaded.push(" +
				"function () {{" +
				"ReevooApi.each(\"{0}\".split(/[ ,]+/), function (retailer) {{" +
						"retailer.init_badges();" +
						"retailer.init_reevoo_reputation_badges();" +
					"}});" +
				"}}" +
			");"; 


        protected override void Render (HtmlTextWriter writer)
        {    
            try {
                string idValue = "reevoomark-loader";
                string typeValue = "text/javascript";        
				string input = String.Format (MARKLOADER_SCRIPT, Trkref);                    
                writer.AddAttribute (HtmlTextWriterAttribute.Id, idValue);
                writer.AddAttribute (HtmlTextWriterAttribute.Type, typeValue);
                writer.RenderBeginTag (HtmlTextWriterTag.Script);
                writer.Write (input);
                writer.RenderEndTag ();
            } catch (Exception e_) {
                throw new ReevooException (e_);
            }
        }
    }
}


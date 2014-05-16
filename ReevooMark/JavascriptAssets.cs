using System;
using ReevooMark;
using System.Web.UI;

namespace ReevooMark
{
	public class JavascriptAssets:AbstractReevooTag
	{

		protected override void OnInit(EventArgs e)
		{

			if (String.IsNullOrEmpty(TkRef))
			{
				Trace.Write("TkRef property is empty; returning nothing");
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{	
			string srcValue = String.Format(@"http://mark.reevoo.com/reevoomark/{0}.js", TkRef);
			Console.WriteLine (srcValue);

			writer.AddAttribute(HtmlTextWriterAttribute.Src, srcValue);
			writer.RenderBeginTag (HtmlTextWriterTag.Script);
			writer.RenderEndTag();
		}
			

	}
}


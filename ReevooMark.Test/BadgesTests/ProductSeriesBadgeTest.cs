using NUnit.Framework;
using System;
using System.Web.UI;

namespace ReevooMark.Test
{
	[TestFixture ()]
	public class ProductSeriesBadgeTest
	{

		ProductSeriesBadge ps_badge = new ProductSeriesBadge ();

		[Test ()]
		public void TestFormatsTheCorrectAnchor()
		{	
			System.IO.StringWriter sw = new System.IO.StringWriter ();
			HtmlTextWriter writer = new HtmlTextWriter(sw);
			ps_badge.TRKREF = "BAR";
			ps_badge.SKU = "FOO";
			ps_badge.RenderControl(writer);
			Assert.AreEqual("<a class=\"reevoomark\" href=\"//mark.reevoo.com/partner/BAR/series:FOO\"></a>", sw.ToString());
		}

		[Test ()]
		public void TestThatIfVariantNamePresentItPrintsTheRightAnchorClass()
		{
			System.IO.StringWriter sw = new System.IO.StringWriter ();
			HtmlTextWriter writer = new HtmlTextWriter(sw);
			ps_badge.TRKREF = "BAR";
			ps_badge.SKU = "FOO";
			ps_badge.VariantName = "search_page";
			ps_badge.RenderControl(writer);
			Console.WriteLine (sw.ToString ());
			Assert.AreEqual("<a class=\"reevoomark search_page_variant\" href=\"//mark.reevoo.com/partner/BAR/series:FOO\"></a>", sw.ToString());

		}

	}
}


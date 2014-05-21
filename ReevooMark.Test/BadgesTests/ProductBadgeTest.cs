using NUnit.Framework;
using System;
using System.Web.UI;

namespace ReevooMark.Test
{
	[TestFixture ()]
	public class ProductBadgeTest
	{
		ProductBadge product_badge = new ProductBadge ();

		[Test ()]
		public void TestFormatsTheCorrectAnchor()
		{	
			System.IO.StringWriter sw = new System.IO.StringWriter ();
			HtmlTextWriter writer = new HtmlTextWriter(sw);
			product_badge.TRKREF = "BAR";
			product_badge.SKU = "FOO";
			product_badge.RenderControl(writer);
			Assert.AreEqual("<a class=\"reevoomark\" href=\"//mark.reevoo.com/partner/BAR/FOO\"></a>", sw.ToString());
		}

		[Test ()]
		public void TestThatIfVariantNamePresentItPrintsTheRightAnchorClass()
		{
			System.IO.StringWriter sw = new System.IO.StringWriter ();
			HtmlTextWriter writer = new HtmlTextWriter(sw);
			product_badge.TRKREF = "BAR";
			product_badge.SKU = "FOO";
			product_badge.VariantName = "search_page";
			product_badge.RenderControl(writer);
			Assert.AreEqual("<a class=\"reevoomark search_page_variant\" href=\"//mark.reevoo.com/partner/BAR/FOO\"></a>", sw.ToString());

		}


		[Test ()]
		public void TestThatIfTrkrefNotSpecifyItWillUseTheOneDefinedInTheWebConfigFile()
		{
			CustomerServiceRatingBadge cs_badge_without_trkref = new CustomerServiceRatingBadge ();
			System.IO.StringWriter sw = new System.IO.StringWriter ();
			HtmlTextWriter writer = new HtmlTextWriter(sw);
			cs_badge_without_trkref.RenderControl(writer);
			//	Console.WriteLine ("The TRKREF is: "+ cs_badge_without_trkref.TRKREF);
			//	Console.WriteLine ("From web config" + WebConfigurationManager.AppSettings["TRKREF"]);
			//Console.WriteLine (sw.ToString ());
			// Assert.AreEqual("", sw.ToString());
		}
	}
}


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
            product_badge.Trkref = "BAR";
            product_badge.Sku = "FOO";
            product_badge.RenderControl(writer);
            Assert.AreEqual("<a class=\"reevoomark\" href=\"//mark.reevoo.com/partner/BAR/FOO\"></a>", sw.ToString());
        }

        [Test ()]
        public void TestThatIfVariantNamePresentItPrintsTheRightAnchorClass()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter ();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            product_badge.Trkref = "BAR";
            product_badge.Sku = "FOO";
            product_badge.VariantName = "search_page";
            product_badge.RenderControl(writer);
            Assert.AreEqual("<a class=\"reevoomark search_page_variant\" href=\"//mark.reevoo.com/partner/BAR/FOO\"></a>", sw.ToString());

        }
            
    }
}


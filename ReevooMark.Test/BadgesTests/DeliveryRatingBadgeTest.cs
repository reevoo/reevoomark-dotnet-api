using NUnit.Framework;
using System;
using System.Web.UI;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class DeliveryRatingBadgeTest
    {
        DeliveryRatingBadge delivery_badge = new DeliveryRatingBadge();

        [Test()]
        public void TestFormatsTheCorrectAnchor()
        {    
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            delivery_badge.Trkref = "FOO";
            delivery_badge.RenderControl(writer);
            Assert.AreEqual("<a class=\"reevoo_reputation delivery\" href=\"//mark.reevoo.com/retailer/FOO\"></a>", sw.ToString());
        }

        [Test()]
        public void TestThatIfVariantNamePresentItPrintsTheRightAnchorClass()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            delivery_badge.Trkref = "BAR";
            delivery_badge.VariantName = "undecorated";
            delivery_badge.RenderControl(writer);
            Assert.AreEqual("<a class=\"reevoo_reputation delivery undecorated\" href=\"//mark.reevoo.com/retailer/BAR\"></a>", sw.ToString());
        }
    }
}



using NUnit.Framework;
using System;
using System.Web.UI;
using System.Web.Configuration;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class CustomerServiceRatingBadgeTest
    {
        CustomerServiceRatingBadge cs_badge = new CustomerServiceRatingBadge();

        [Test()]
        public void TestFormatsTheCorrectAnchor()
        {    
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            cs_badge.Trkref = "BAR";
            cs_badge.RenderControl(writer);
            Assert.AreEqual("<a class=\"reevoo_reputation customer_service\" href=\"//mark.reevoo.com/retailer/BAR\"></a>", sw.ToString());
        }

        [Test()]
        public void TestThatIfVariantNamePresentItPrintsTheRightAnchorClass()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            cs_badge.Trkref = "BAR";
            cs_badge.VariantName = "undecorated";
            cs_badge.RenderControl(writer);
            Assert.AreEqual("<a class=\"reevoo_reputation customer_service undecorated\" href=\"//mark.reevoo.com/retailer/BAR\"></a>", sw.ToString());
        }
            
    }
}



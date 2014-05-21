using NUnit.Framework;
using System;
using System.Web.UI;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class OverallServiceRatingBadgeTest
    {
        OverallServiceRatingBadge reputation_badge = new OverallServiceRatingBadge();

        [Test()]
        public void TestFormatsTheCorrectAnchor()
        {    
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            reputation_badge.TRKREF = "FOO";
            reputation_badge.RenderControl(writer);
            Assert.AreEqual("<a class=\"reevoo_reputation\" href=\"//mark.reevoo.com/retailer/FOO\"></a>", sw.ToString());
        }

        [Test()]
        public void TestThatIfVariantNamePresentItPrintsTheRightAnchorClass()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            reputation_badge.TRKREF = "BAR";
            reputation_badge.VariantName = "undecorated";
            reputation_badge.RenderControl(writer);
            Console.WriteLine(sw.ToString());
            Assert.AreEqual("<a class=\"reevoo_reputation undecorated\" href=\"//mark.reevoo.com/retailer/BAR\"></a>", sw.ToString());
        }


    }
}


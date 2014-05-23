using NUnit.Framework;
using System;
using System.Web.UI;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class ConversationSeriesBadgeTest
    {
        ConversationSeriesBadge csb = new ConversationSeriesBadge();

        [Test()]
        public void TestFormatsTheCorrectAnchor()
        {    
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            csb.Sku = "FOO";
            csb.Trkref = "BAR";
            csb.RenderControl(writer);
            Assert.AreEqual("<a class=\"reevoomark reevoo-conversations\" href=\"//mark.reevoo.com/partner/BAR/series:FOO\"></a>", sw.ToString());
        }

        [Test()]
        public void TestThatIfVariantNamePresentItPrintsTheRightAnchorClass()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            csb.Sku = "FOO";
            csb.Trkref = "BAR";
            csb.VariantName = "undecorated";
            csb.RenderControl(writer);
            Assert.AreEqual("<a class=\"reevoomark reevoo-conversations undecorated\" href=\"//mark.reevoo.com/partner/BAR/series:FOO\"></a>", sw.ToString());
        }
    }
}


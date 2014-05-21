using System;
using NUnit.Framework;
using System.Web.UI;
using System.IO;
using ReevooMark;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class ConversationsBadgeTest
    {
        ConversationsBadge cb = new ConversationsBadge();

        [Test()]
        public void TestFormatsTheCorrectAnchor()
        {    
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            cb.SKU = "FOO";
            cb.TRKREF = "BAR";
            cb.RenderControl(writer);
            Assert.AreEqual("<a class=\"reevoomark reevoo-conversations\" href=\"//mark.reevoo.com/partner/BAR/FOO\"></a>", sw.ToString());

        }

        [Test()]
        public void TestThatIfVariantNamePresentItPrintsTheRightAnchorClass()
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            cb.SKU = "FOO";
            cb.TRKREF = "BAR";
            cb.VariantName = "undecorated";
            cb.RenderControl(writer);
            Assert.AreEqual("<a class=\"reevoomark reevoo-conversations undecorated\" href=\"//mark.reevoo.com/partner/BAR/FOO\"></a>", sw.ToString());
        }
    }
}


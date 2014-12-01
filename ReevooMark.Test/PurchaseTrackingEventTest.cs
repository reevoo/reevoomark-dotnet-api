using NUnit.Framework;
using System;
using ReevooMark;
using System.Web.UI;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class PurchaseTrackingEventTest
    {
        [Test()]
        public void TestCase()
        {
            PurchaseTrackingEvent purchaseEvent = new PurchaseTrackingEvent();
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            purchaseEvent.Trkref = "FOO";
            purchaseEvent.Skus = "111,222,333";
            purchaseEvent.Value = "243";
            purchaseEvent.RenderControl(writer);
            string content_without_new_line = sw.ToString().Replace(System.Environment.NewLine, "");
            Assert.AreEqual(content_without_new_line, "<script type=\"text/javascript\">\tif (typeof afterReevooMarkLoaded === 'undefined') {var afterReevooMarkLoaded = [];};afterReevooMarkLoaded.push(function(){ReevooApi.load(\"FOO\", function(retailer){retailer.track_purchase(\"111,222,333\".split(/[ ,]+/), \"243\");});});</script>");
        }
            
    }
}

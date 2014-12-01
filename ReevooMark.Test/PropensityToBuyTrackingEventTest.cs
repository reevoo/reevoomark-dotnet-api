using NUnit.Framework;
using System;
using ReevooMark;
using System.Web.UI;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class PropensityToBuyTrackingEventTest
    {
        [Test()]
        public void TestWithSkuCase()
        {
            PropensityToBuyTrackingEvent propensity = new PropensityToBuyTrackingEvent();
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            propensity.Trkref = "FOO";
            propensity.Action = "download_brochure";
            propensity.Sku = "123";
            propensity.RenderControl(writer);
            string content_without_new_line = sw.ToString().Replace(System.Environment.NewLine, "");
            Assert.AreEqual(content_without_new_line, "<script type=\"text/javascript\">\tif (typeof afterReevooMarkLoaded === 'undefined') {var afterReevooMarkLoaded = [];};afterReevooMarkLoaded.push(function(){ReevooApi.load(\"FOO\", function(retailer){retailer.Tracking.ga_track_event(\"Propensity to buy\", \"download_brochure\", \"123\");retailer.track_exit();});});</script>");

        }

        [Test()]
        public void TestWithWithoutSkuCase()
        {
            PropensityToBuyTrackingEvent propensity = new PropensityToBuyTrackingEvent();
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            propensity.Trkref = "FOO";
            propensity.Action = "download_brochure";
            propensity.RenderControl(writer);
            string content_without_new_line = sw.ToString().Replace(System.Environment.NewLine, "");
            Assert.AreEqual(content_without_new_line, "<script type=\"text/javascript\">\tif (typeof afterReevooMarkLoaded === 'undefined') {var afterReevooMarkLoaded = [];};afterReevooMarkLoaded.push(function(){ReevooApi.load(\"FOO\", function(retailer){retailer.Tracking.ga_track_event(\"Propensity to buy\", \"download_brochure\", \"Global CTA\");retailer.track_exit();});});</script>");

        }

    }
}


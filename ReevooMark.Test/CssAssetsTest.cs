using NUnit.Framework;
using System;
using ReevooMark;
using System.Web.UI;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class CssAssetsTest
    {
        [Test()]
        public void TestCase()
        {
            CssAssets css = new CssAssets();
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            css.RenderControl(writer);
            Assert.AreEqual(sw.ToString(), "<link rel=\"stylesheet\" href=\"" + Config.BaseUriAssets() + "stylesheets/reevoomark/embedded_reviews.css\" type=\"text/css\" />");
        }
    }
}


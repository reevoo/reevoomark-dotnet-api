using NUnit.Framework;
using System;
using ReevooMark;
using System.Web.UI;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class JavascriptAssetsTest
    {
        [Test()]
        public void TestCase()
        {
            JavascriptAssets js = new JavascriptAssets();
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            js.Trkref = "FOO";
            js.RenderControl(writer);
            Assert.AreEqual(sw.ToString(), "<script id=\"reevoomark-loader\" type=\"text/javascript\">\n\t(function () {var script = document.createElement('script'); script.type = 'text/javascript'; script.src = '//cdn.mark.reevoo.com/assets/reevoo_mark.js';var s = document.getElementById('reevoomark-loader'); s.parentNode.insertBefore(script, s); })();afterReevooMarkLoaded = [];afterReevooMarkLoaded.push(function () {ReevooApi.load(\"FOO\", function (retailer) {retailer.init_badges();retailer.init_reevoo_reputation_badges();});});\n</script>");
        
        }
    }
}


using NUnit.Framework;
using System;
using ReevooMark;
using System.Net;
using System.Web.UI;
using System.IO;


namespace ReevooMark.Test
{
	[TestFixture ()]
	public class ReevooCustomerExperienceReviewsTest
	{
	
		[Test]
		[Category("Requires network connection")]
		public void TestCustomerExperienceReviewsData()
		{
			CustomerExperienceReviews cx_reviews = new CustomerExperienceReviews();
			System.IO.StringWriter sw = new System.IO.StringWriter ();
			HtmlTextWriter writer = new HtmlTextWriter(sw);
			cx_reviews.SKU = "";
			cx_reviews.TRKREF = "CYS";
			cx_reviews.RenderControl (writer);
			//	Console.WriteLine (sw.ToString());
			//    Assert.AreEqual("", sw.ToString());
		}
	}
}

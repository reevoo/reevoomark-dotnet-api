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
			cx_reviews.SKU = "";
			cx_reviews.TkRef = "CYS";
//			Console.WriteLine (cx_reviews.GetContent());
			//Assert.AreEqual("http://mark.reevoo.com/reevoomark/embeddable_customer_experience_reviews?retailer=CYS&sku=",  cx_reviews.GetContent());
		}
	}
}

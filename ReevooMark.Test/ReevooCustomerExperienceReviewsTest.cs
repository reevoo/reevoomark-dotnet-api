using NUnit.Framework;
using System;
using ReevooMark;
using System.Net;
using System.Web;


namespace ReevooMark.Test
{
	[TestFixture ()]
	public class ReevooCustomerExperienceReviewsTest
	{


		[Test]
		[Category("Requires network connection")]
		public void TestCustomerExperienceReviewsData()
		{
	
			//	Console.WriteLine (new ReevooCustomerExperienceReviews ().GetContent (_tkref, _sku));
			//		Assert.AreEqual("http://mark.reevoo.com/reevoomark/embeddable_customer_experience_reviews?retailer=foo&sku=bar",  new ReevooCustomerExperienceReviews().GetContent(_tkref, _sku));
		}
	}
}

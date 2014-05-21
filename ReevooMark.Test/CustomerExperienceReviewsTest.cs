using NUnit.Framework;
using System;
using ReevooMark;
using System.Net;
using System.Web.UI;
using System.IO;
using Moq;


namespace ReevooMark.Test
{
	[TestFixture]
	public class ReevooCustomerExperienceReviewsTest
	{
	
		Mock<ReevooClient> mock_client;
		CustomerExperienceReviews cx_reviews;

		[SetUp]
		public void setup()
		{
			this.mock_client = new Mock<ReevooClient>();
			this.cx_reviews = new CustomerExperienceReviews();
			this.cx_reviews.TRKREF = "FOO";
			this.cx_reviews.client = mock_client.Object;
		}

		public void RenderBadge(AbstractReevooMarkClientTag tag){
			System.IO.StringWriter sw = new System.IO.StringWriter ();
			HtmlTextWriter writer = new HtmlTextWriter(sw);
			tag.RenderControl (writer);
		}

		[Test]
		public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpoint()
		{

			RenderBadge (this.cx_reviews);
			this.mock_client.Verify(x => x.ObtainReevooMarkData("FOO", null, "http://mark.reevoo.com/reevoomark/embeddable_customer_experience_reviews"));

		}

		[Test]
		public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingLocale()
		{
			this.cx_reviews.NumberOfReviews = "5";
			RenderBadge (this.cx_reviews);
			this.mock_client.Verify(x => x.ObtainReevooMarkData("FOO", null, "http://mark.reevoo.com/reevoomark/5/embeddable_customer_experience_reviews"));

		}

		[Test]
		public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingNumberOfReviews()
		{
			this.cx_reviews.Locale= "fr-FR";
			RenderBadge (this.cx_reviews);
			this.mock_client.Verify(x => x.ObtainReevooMarkData("FOO", null, "http://mark.reevoo.com/reevoomark/fr-FR/embeddable_customer_experience_reviews"));

		}

		[Test]
		public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingLocaleAndNumberOfReviews()
		{
			this.cx_reviews.NumberOfReviews = "5";
			this.cx_reviews.Locale= "fr-FR";
			RenderBadge (this.cx_reviews);
			this.mock_client.Verify(x => x.ObtainReevooMarkData("FOO", null, "http://mark.reevoo.com/reevoomark/fr-FR/5/embeddable_customer_experience_reviews"));

		}





	}
}

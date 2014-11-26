using NUnit.Framework;
using System;
using ReevooMark;
using System.Net;
using System.Web.UI;
using System.IO;
using Rhino.Mocks;

namespace ReevooMark.Test
{
    [TestFixture]
    public class ReevooCustomerExperienceReviewsTest
    {
        ReevooClient mock_client;
        CustomerExperienceReviews cx_reviews;

        [SetUp]
        public void setup()
        {
            this.mock_client = MockRepository.GenerateMock<ReevooClient>();
            this.cx_reviews = new CustomerExperienceReviews();
            this.cx_reviews.Trkref = "FOO";
            this.cx_reviews.client = mock_client;
        }

        public void RenderBadge(AbstractReevooMarkClientTag tag)
        {
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter writer = new HtmlTextWriter(sw);
            tag.RenderControl(writer);
        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpoint()
        {

            this.mock_client.Expect(x => x.ObtainReevooMarkData(new Parameters("trkref", "FOO"), "http://mark.reevoo.com/reevoomark/embeddable_customer_experience_reviews")).Return(new ReevooMarkData());
            RenderBadge(this.cx_reviews);
            this.mock_client.VerifyAllExpectations();
        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingLocale()
        {
            this.cx_reviews.NumberOfReviews = "5";         
            this.mock_client.Expect(x => x.ObtainReevooMarkData(new Parameters("trkref", "FOO"), "http://mark.reevoo.com/reevoomark/5/embeddable_customer_experience_reviews")).Return(new ReevooMarkData());
            RenderBadge(this.cx_reviews);
            this.mock_client.VerifyAllExpectations();
        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingNumberOfReviews()
        {
            this.cx_reviews.Locale = "fr-FR";
            this.mock_client.Expect(x => x.ObtainReevooMarkData(new Parameters("trkref", "FOO"), "http://mark.reevoo.com/reevoomark/fr-FR/embeddable_customer_experience_reviews")).Return(new ReevooMarkData());
            RenderBadge(this.cx_reviews);
            this.mock_client.VerifyAllExpectations();
        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingLocaleAndNumberOfReviews()
        {
            this.cx_reviews.NumberOfReviews = "5";
            this.cx_reviews.Locale = "fr-FR";   
            this.mock_client.Expect(x => x.ObtainReevooMarkData(new Parameters("trkref", "FOO"), "http://mark.reevoo.com/reevoomark/fr-FR/5/embeddable_customer_experience_reviews")).Return(new ReevooMarkData());
            RenderBadge(this.cx_reviews);
            this.mock_client.VerifyAllExpectations();
        }
    }
}

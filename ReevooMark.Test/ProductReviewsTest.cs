using NUnit.Framework;
using System;
using Rhino.Mocks;
using System.Web.UI;
using System.Collections.Generic;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class ProductReviewsTest
    {

        ReevooClient mock_client;
        ProductReviews p_reviews;

        [SetUp]
        public void setup()
        {
            // Very helpful for debugging
            RhinoMocks.Logger = new Rhino.Mocks.Impl.TextWriterExpectationLogger(Console.Out);

            this.mock_client = MockRepository.GenerateMock<ReevooClient>();
            this.p_reviews = new ProductReviews();
            this.p_reviews.Trkref = "FOO";
            this.p_reviews.client = mock_client;
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
            this.mock_client.Expect(x => x.ObtainReevooMarkData(new Parameters("trkref", "FOO"), Config.BaseUri() + "reevoomark/embeddable_reviews")).Return(new ReevooMarkData());
            RenderBadge(this.p_reviews);
            mock_client.VerifyAllExpectations();

        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingLocale()
        {
            this.p_reviews.NumberOfReviews = "5";
            Parameters expected = new Parameters("trkref", "FOO", "reviews", "5");
            this.mock_client.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_reviews")).Return(new ReevooMarkData());
            RenderBadge(this.p_reviews);
            mock_client.VerifyAllExpectations();

        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingNumberOfReviews()
        {
            this.p_reviews.Locale = "fr-FR";
            Parameters expected = new Parameters("trkref", "FOO", "locale", "fr-FR");
            this.mock_client.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_reviews")).Return(new ReevooMarkData());
            RenderBadge(this.p_reviews);
            mock_client.VerifyAllExpectations();

        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingLocaleAndNumberOfReviews()
        {
            this.p_reviews.NumberOfReviews = "5";
            this.p_reviews.Locale = "fr-FR";
            Parameters expected = new Parameters("trkref", "FOO", "reviews", "5", "locale", "fr-FR");
            this.mock_client.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_reviews")).Return(new ReevooMarkData());
            RenderBadge(this.p_reviews);
            mock_client.VerifyAllExpectations();
        }
            
    }
}
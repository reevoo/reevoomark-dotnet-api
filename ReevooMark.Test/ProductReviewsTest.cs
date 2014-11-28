using NUnit.Framework;
using System;
using Rhino.Mocks;
using System.Web.UI;
using System.Web;
using System.Collections.Specialized;

namespace ReevooMark.Test
{
    [TestFixture()]
    public class ProductReviewsTest
    {

        ReevooClient mockedClient;
        ProductReviews productReviews;

        [SetUp]
        public void setup()
        {
            // Very helpful for debugging
            RhinoMocks.Logger = new Rhino.Mocks.Impl.TextWriterExpectationLogger(Console.Out);

            mockedClient = MockRepository.GenerateMock<ReevooClient>();
            productReviews = MockRepository.GeneratePartialMock<ProductReviews>();
            productReviews.Stub(x => x.ClientUrl()).Return(null);
            productReviews.Trkref = "FOO";
            productReviews.client = mockedClient;
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
            mockedClient.Expect(x => x.ObtainReevooMarkData(new Parameters("trkref", "FOO"), Config.BaseUri() + "reevoomark/embeddable_reviews")).Return(new ReevooMarkData());
            RenderBadge(productReviews);
            mockedClient.VerifyAllExpectations();

        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingLocale()
        {
            productReviews.NumberOfReviews = "5";

            Parameters expected = new Parameters("trkref", "FOO", "reviews", "5");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_reviews")).Return(new ReevooMarkData());
            RenderBadge(productReviews);
            mockedClient.VerifyAllExpectations();

        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingNumberOfReviews()
        {
            productReviews.Locale = "fr-FR";

            Parameters expected = new Parameters("trkref", "FOO", "locale", "fr-FR");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_reviews")).Return(new ReevooMarkData());
            RenderBadge(productReviews);
            mockedClient.VerifyAllExpectations();

        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingLocaleAndNumberOfReviews()
        {
            productReviews.NumberOfReviews = "5";
            productReviews.Locale = "fr-FR";

            Parameters expected = new Parameters("trkref", "FOO", "reviews", "5", "locale", "fr-FR");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_reviews")).Return(new ReevooMarkData());
            RenderBadge(productReviews);
            mockedClient.VerifyAllExpectations();
        }

        [Test]
        public void TestPaginatedProductReviews()
        {
            productReviews.Stub(x => x.ParamCollection()).Return(new NameValueCollection());
            productReviews.Paginated = "true";
            productReviews.Trkref = "REV";

            Parameters expected = new Parameters("trkref", "REV", "per_page", "default", "page", "1");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_reviews")).Return(new ReevooMarkData());
            RenderBadge(productReviews);
            mockedClient.VerifyAllExpectations();
        }

        [Test]
        public void TestPaginatedProductReviewsPage()
        {
            productReviews.Stub(x => x.ParamCollection()).Return(new NameValueCollection() { { "reevoo_page", "7" }, });
            productReviews.Paginated = "true";
            productReviews.Trkref = "AUU";

            Parameters expected = new Parameters("trkref", "AUU", "per_page", "default", "page", "7");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_reviews")).Return(new ReevooMarkData());
            RenderBadge(productReviews);
            mockedClient.VerifyAllExpectations();
        }

        [Test]
        public void TestPaginatedProductReviewsPerPage()
        {
            productReviews.Stub(x => x.ParamCollection()).Return(new NameValueCollection());
            productReviews.Paginated = "true";
            productReviews.Trkref = "POU";
            productReviews.NumberOfReviews = "5";

            Parameters expected = new Parameters("trkref", "POU", "per_page", "default", "page", "1", "per_page", "5");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_reviews")).Return(new ReevooMarkData());
            RenderBadge(productReviews);
            mockedClient.VerifyAllExpectations();
        }

        [Test]
        public void TestPaginatedProductReviewsSortBy()
        {
            productReviews.Stub(x => x.ParamCollection()).Return(new NameValueCollection() { { "reevoo_sort_by", "lowest_score" }, });
            productReviews.Paginated = "true";
            productReviews.Trkref = "KYH";

            Parameters expected = new Parameters("trkref", "KYH", "per_page", "default", "page", "1", "sort_by", "lowest_score");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_reviews")).Return(new ReevooMarkData());
            RenderBadge(productReviews);
            mockedClient.VerifyAllExpectations();
        }

        [Test]
        public void TestPaginatedProductReviewsFilter()
        {
            productReviews.Stub(x => x.ParamCollection()).Return(new NameValueCollection() { { "reevoo_filter", "moms" }, });
            productReviews.Paginated = "true";
            productReviews.Trkref = "XES";

            Parameters expected = new Parameters("trkref", "XES", "per_page", "default", "page", "1", "filter", "moms");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_reviews")).Return(new ReevooMarkData());
            RenderBadge(productReviews);
            mockedClient.VerifyAllExpectations();
        }
    }
}
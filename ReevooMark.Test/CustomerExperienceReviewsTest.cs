using NUnit.Framework;
using System;
using ReevooMark;
using System.Net;
using System.Web.UI;
using System.IO;
using Rhino.Mocks;
using System.Collections.Specialized;

namespace ReevooMark.Test
{
    [TestFixture]
    public class ReevooCustomerExperienceReviewsTest
    {
        ReevooClient mockedClient;
        CustomerExperienceReviews cxReviews;

        [SetUp]
        public void setup()
        {
            mockedClient = MockRepository.GenerateMock<ReevooClient>();
            cxReviews = MockRepository.GeneratePartialMock<CustomerExperienceReviews>();
            cxReviews.Trkref = "FOO";
            cxReviews.client = mockedClient;
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
            mockedClient.Expect(x => x.ObtainReevooMarkData(new Parameters("trkref", "FOO"), Config.BaseUri() + "reevoomark/embeddable_customer_experience_reviews")).Return(new ReevooMarkData());
            RenderBadge(cxReviews);
            mockedClient.VerifyAllExpectations();
        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingLocale()
        {
            cxReviews.NumberOfReviews = "5";
            Parameters expected = new Parameters("trkref", "FOO", "reviews", "5");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_customer_experience_reviews")).Return(new ReevooMarkData());
            RenderBadge(cxReviews);
            mockedClient.VerifyAllExpectations();
        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingNumberOfReviews()
        {
            cxReviews.Locale = "fr-FR";
            Parameters expected = new Parameters("trkref", "FOO", "locale", "fr-FR");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_customer_experience_reviews")).Return(new ReevooMarkData());
            RenderBadge(cxReviews);
            mockedClient.VerifyAllExpectations();
        }

        [Test]
        public void TestTagCallsClientWithCorrectAttributesAndTheCXEndpointWhenUsingLocaleAndNumberOfReviews()
        {
            cxReviews.NumberOfReviews = "5";
            cxReviews.Locale = "fr-FR";
            Parameters expected = new Parameters("trkref", "FOO", "locale", "fr-FR", "reviews", "5");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_customer_experience_reviews")).Return(new ReevooMarkData());
            RenderBadge(cxReviews);
            mockedClient.VerifyAllExpectations();
        }

        [Test]
        public void TextPaginatedCXReviews()
        {
            cxReviews.Stub(x => x.ParamCollection()).Return(new NameValueCollection());
            cxReviews.Paginated = "true";
            cxReviews.Trkref = "RYS";

            Parameters expected = new Parameters("trkref", "RYS", "per_page", "default", "page", "1");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_customer_experience_reviews")).Return(new ReevooMarkData());
            RenderBadge(cxReviews);
            mockedClient.VerifyAllExpectations();
        }

        [Test]
        public void TestPaginatedCXReviews()
        {
            cxReviews.Stub(x => x.ParamCollection()).Return(new NameValueCollection());
            cxReviews.Paginated = "true";
            cxReviews.Trkref = "REV";

            Parameters expected = new Parameters("trkref", "REV", "per_page", "default", "page", "1");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_customer_experience_reviews")).Return(new ReevooMarkData());
            RenderBadge(cxReviews);
            mockedClient.VerifyAllExpectations();
        }

        [Test]
        public void TestPaginatedCXReviewsPage()
        {
            cxReviews.Stub(x => x.ParamCollection()).Return(new NameValueCollection() { { "reevoo_page", "7" }, });
            cxReviews.Paginated = "true";
            cxReviews.Trkref = "AUU";

            Parameters expected = new Parameters("trkref", "AUU", "per_page", "default", "page", "7");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_customer_experience_reviews")).Return(new ReevooMarkData());
            RenderBadge(cxReviews);
            mockedClient.VerifyAllExpectations();
        }

        [Test]
        public void TestPaginatedCXReviewsPerPage()
        {
            cxReviews.Stub(x => x.ParamCollection()).Return(new NameValueCollection());
            cxReviews.Paginated = "true";
            cxReviews.Trkref = "POU";
            cxReviews.NumberOfReviews = "5";

            Parameters expected = new Parameters("trkref", "POU", "per_page", "default", "page", "1", "per_page", "5");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_customer_experience_reviews")).Return(new ReevooMarkData());
            RenderBadge(cxReviews);
            mockedClient.VerifyAllExpectations();
        }

        [Test]
        public void TestPaginatedCXReviewsSortBy()
        {
            cxReviews.Stub(x => x.ParamCollection()).Return(new NameValueCollection() { { "reevoo_sort_by", "lowest_score" }, });
            cxReviews.Paginated = "true";
            cxReviews.Trkref = "KYH";

            Parameters expected = new Parameters("trkref", "KYH", "per_page", "default", "page", "1", "sort_by", "lowest_score");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_customer_experience_reviews")).Return(new ReevooMarkData());
            RenderBadge(cxReviews);
            mockedClient.VerifyAllExpectations();
        }

        [Test]
        public void TestPaginatedCXReviewsFilter()
        {
            cxReviews.Stub(x => x.ParamCollection()).Return(new NameValueCollection() { { "reevoo_filter", "moms" }, });
            cxReviews.Paginated = "true";
            cxReviews.Trkref = "XES";

            Parameters expected = new Parameters("trkref", "XES", "per_page", "default", "page", "1", "filter", "moms");
            mockedClient.Expect(x => x.ObtainReevooMarkData(expected, Config.BaseUri() + "reevoomark/embeddable_customer_experience_reviews")).Return(new ReevooMarkData());
            RenderBadge(cxReviews);
            mockedClient.VerifyAllExpectations();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ReevooMark;
using NUnit.Framework;
using System.Net;

namespace ReevooMark.Test
{
    /// <summary>
    /// ReevooMark.Test unit tests for ReevooMark.ReevooClient test the internal parsing logic of ReevooClient.
    /// 
    /// To run:
    /// 
    /// nunit.exe 
    /// </summary>
    [TestFixture]
    public class ReevooClientTests
    {
        private WebHeaderCollection _goodHeaders;
        private WebHeaderCollection _badHeaders;

        [TestFixtureSetUp]
        public void Setup()
        {
            _goodHeaders = CreateGoodHeaders();
            _badHeaders = CreateBadHeaders();
        }

        /// <summary>
        /// Creates a collection similar to that returned by the
        /// ReevooMark service with 'good' - i.e. expected - data.
        /// </summary>
        /// <returns></returns>
        private WebHeaderCollection CreateGoodHeaders()
        {
            var _headers = new WebHeaderCollection();

            _headers[ReevooClient.HEADER_BEST_PRICE] = "1.38";
            _headers[ReevooClient.HEADER_OVERALL_SCORE] = "9.4";
            _headers[ReevooClient.HEADER_REVIEW_COUNT] = "3";
            _headers[ReevooClient.HEADER_SCORE_COUNT] = "1200";

            return _headers;
        }

        /// <summary>
        /// Creates a collection similar to that returned by the
        /// ReevooMark service with faulty data.
        /// </summary>
        /// <returns></returns>
        private WebHeaderCollection CreateBadHeaders()
        {
            var _headers = new WebHeaderCollection();

            _headers[ReevooClient.HEADER_BEST_PRICE] = null; //this should be a string
            _headers[ReevooClient.HEADER_OVERALL_SCORE] = String.Empty; //this should be a string
            _headers[ReevooClient.HEADER_REVIEW_COUNT] = "3.890"; //this is supposed to be an int
            _headers[ReevooClient.HEADER_SCORE_COUNT] = "2147483648"; //int.MaxValue + 1

            return _headers;
        }

        [Test]
        public void TestGetQueryString()
        {
            string _sku = @"foo";
            string _trkref = @"bar";

            StringAssert.IsMatch("sku=foo&retailer=bar", ReevooClient.GetQueryString(_trkref, _sku));
        }

        [Test]
        public void TestGetOverallScore()
        {
            Assert.AreEqual("9.4", ReevooClient.GetOverallScore(_goodHeaders), "GetOverallScore parsing logic failed");
            Assert.IsEmpty(ReevooClient.GetOverallScore(_badHeaders), "GetOverallScore should return empty for bad data");
        }

        [Test]
        public void TestGetBestPrice()
        {
            Assert.AreEqual("1.38", ReevooClient.GetBestPrice(_goodHeaders), "GetBestPrice parsing logic failed");
            Assert.IsEmpty(ReevooClient.GetBestPrice(_badHeaders), "GetBestPrice should return empty for bad data");
        }

        [Test]
        public void TestGetScoreCount()
        {
            Assert.AreEqual(1200, ReevooClient.GetScoreCount(_goodHeaders), "GetScoreCount parsing logic failed");
            Assert.AreEqual(0, ReevooClient.GetScoreCount(_badHeaders), "GetScoreCount should return zero for bad data");
        }

        [Test]
        public void TestGetReviewCount()
        {
            Assert.AreEqual(3, ReevooClient.GetReviewCount(_goodHeaders), "GetReviewCount parsing logic failed");
            Assert.AreEqual(0, ReevooClient.GetReviewCount(_badHeaders), "GetReviewCount should return zero for bad data");
        }

        [Test]
        [Category("Requires network connection")]
        public void TestGetReevooMarkData()
        {
            Assert.AreNotEqual(String.Empty, new ReevooClient().ObtainReevooMarkData("TSC", "67255143", "http://mark.reevoo.com/reevoomark/en-GB/embeddable_reviews").Content);
        }

        [Test]
        [Category("Requires network connection")]
        public void TestGetSeriesReevooMarkData()
        {
            Assert.AreNotEqual(String.Empty, new ReevooClient().ObtainReevooMarkData("GMXT-FOC-N", "series:ford-ka", "http://mark.reevoo.com/reevoomark/en-GB/embeddable_reviews").Content);
        }
    }
}

using System;
using System.Net;
using System.Net.Cache;
using System.IO;
using System.Threading;

namespace ReevooMark
{
    /// <summary>
    /// Simple HTTP agent used for getting Reevoo Mark data.
    /// <remarks>
    /// ReevooClient uses a System.Net.WebRequest to cache the results of an HTTP GET
    /// request if appropriate.
    /// 
    /// To set a default proxy for all your application's <see cref="System.Net.WebRequest"/>s,
    /// (including those used by ReevooClient), set the property <see cref="System.Net.WebRequest.DefaultWebProxy"/>
    /// before calling <see cref="ReevooClient.ObtainReevooMarkData()"/>.
    /// </remarks>
    /// </summary>
    public class ReevooClient
    {
        //members marked as 'internal' - package visibility. 'InternalsVisibleTo' attribute
        //in AssemblyInfo.cs exposes internal members to the test assembly.
        internal const String QUERYSTRING_SKU = "sku";
        internal const String QUERYSTRING_RETAILER = "retailer";
        internal const String HEADER_OVERALL_SCORE = "X-Reevoo-OverallScore";
        internal const String HEADER_SCORE_COUNT = "X-Reevoo-ScoreCount";
        internal const String HEADER_REVIEW_COUNT = "X-Reevoo-ReviewCount";
        internal const String HEADER_BEST_PRICE = "X-Reevoo-BestPrice";
        internal const String REEVOO_QUERYSTRING_FORMAT = @"{0}={1}&{2}={3}";
        internal const int DEFAULT_NETWORK_TIMEOUT = 2000;
        /// <summary>
        /// The default timeout for requests in milliseconds.
        /// </summary>
        private int _timeout;

        /// <summary>
        /// Declares the signature for the ObtainReevooMarkDataInternal function,
        /// allowing it to be run asynchronously
        /// </summary>
        private delegate ReevooMarkData ObtainMarkDataDelegate (String trkref_, String sku_, String baseUri_);

        #region Constructors

        /// <summary>
        /// Construct a ReevooClient with the given timeout in milliseconds.
        /// </summary>
        public ReevooClient (int timeout_)
        {
            _timeout = timeout_;
        }

        /// <summary>
        /// Construct a ReevooClient with the default timeout.
        /// </summary>
        public ReevooClient () : this (DEFAULT_NETWORK_TIMEOUT)
        {
        }

        #endregion

        #region Public API

        /// <summary>
        /// Get ReevooMark data for a given product and retailer code.
        /// </summary>
        /// <param name="trkref_">Your retailer code</param>
        /// <param name="sku_">The product code</param>
        /// <param name="baseUri_">The base URI for the request - provided by Reevoo.</param>
        /// <returns>An instance of <see cref="ReevooMarkData"/></returns>
        /// <exception cref="ReevooException">If anything bad happened whilst getting mark data</exception>
        public virtual ReevooMarkData ObtainReevooMarkData (String trkref_, String sku_, String baseUri_)
        {
            //this function delegates to 'ObtainReevooMarkDataInternal', which handles
            //the logic of actually getting and parsing the data from the ReevooMark service.

            //this function is responsible for maintaining an overall timeout for that operation.

            //this is necessary because, whilst the WebRequest class has its own timeout, the
            //DNS lookup timeout is an OS setting and is not settable from user code.

            //therefore, if the *whole* operation takes longer than the timeout defined in 
            //the constructor (or DEFAULT_NETWORK_TIMEOUT), we throw a ReevooException containing
            //a TimeoutException.

            var _doWork = new ObtainMarkDataDelegate (ObtainReevooMarkDataInternal);

            var _iar = _doWork.BeginInvoke (trkref_, sku_, baseUri_, null, null);

            if (!_iar.AsyncWaitHandle.WaitOne (_timeout, false)) {
                throw new ReevooException (new TimeoutException ("Web request timed out."));
            } else {
                return _doWork.EndInvoke (_iar);
            }
        }

        #endregion

        /// <summary>
        /// Internal method which does the actual work of getting the Mark data.
        /// </summary>
        private ReevooMarkData ObtainReevooMarkDataInternal (String trkref_, String sku_, String baseUri_)
        {
            var _builder = new UriBuilder (baseUri_);
            _builder.Query = GetQueryString (trkref_, sku_);

            HttpWebRequest _req = (HttpWebRequest)WebRequest.Create (_builder.ToString ());

            //Explicitly set the cache level. .NET Framework default is to always bypass the
            //cache and go straight to the server. RequestCacheLevel.Default will request cache-control
            //and age headers defined in RFC-2616.
            var _cachePolicy = new System.Net.Cache.RequestCachePolicy (RequestCacheLevel.Default);

            _req.CachePolicy = _cachePolicy;

            HttpWebResponse _res = null;
            String _content = String.Empty;
            try {
                //stream web content into a string
                try {
                    _res = (HttpWebResponse)_req.GetResponse ();
                } catch (WebException e) {
                    _res = (HttpWebResponse)e.Response;
                }
                if( _res.StatusCode == HttpStatusCode.OK){
                    using (var s = new StreamReader (_res.GetResponseStream ())) {
                        _content = s.ReadToEnd ();
                    }
                } else {
                    _content = null;    
                }
 
            } catch (Exception e_) {
                throw new ReevooException (e_);
            }
            
            return new ReevooMarkData {
                Content = _content,
                BestPrice = GetBestPrice (_res.Headers),
                ReviewCount = GetReviewCount (_res.Headers),
                ScoreCount = GetScoreCount (_res.Headers),
                OverallScore = GetOverallScore (_res.Headers),
                Retailer = trkref_,
                Sku = sku_
            };
        }

        /// <summary>
        /// Constructs a querystring based on product and retailer codes.
        /// </summary>
        internal static string GetQueryString (string trkref_, string sku_)
        {
            //construct a string in the format "sku=foo&retailer=bar"
            return String.Format (REEVOO_QUERYSTRING_FORMAT, QUERYSTRING_SKU, sku_, QUERYSTRING_RETAILER, trkref_);
        }

        #region Get header data

        /// <summary>
        /// Returns the 'overall score' member from the returned data structure
        /// </summary>
        internal static string GetOverallScore (WebHeaderCollection webHeaderCollection_)
        {
            String _overallScore = webHeaderCollection_ [HEADER_OVERALL_SCORE];
            if (String.IsNullOrEmpty (_overallScore)) {
                return String.Empty;
            } else {
                return _overallScore;
            }
        }

        /// <summary>
        /// Returns the 'best price' member from the returned data structure
        /// </summary>
        internal static String GetBestPrice (WebHeaderCollection webHeaderCollection_)
        {
            String _bestPrice = webHeaderCollection_ [HEADER_BEST_PRICE];
            if (string.IsNullOrEmpty (_bestPrice)) {
                return string.Empty;
            } else {
                return _bestPrice;
            }
        }

        /// <summary>
        /// Returns the 'score count' member from the returned data structure
        /// </summary>
        internal static int GetScoreCount (WebHeaderCollection webHeaderCollection_)
        {
            int _scoreCount;
            if (int.TryParse (webHeaderCollection_ [HEADER_SCORE_COUNT], out _scoreCount)) {
                return _scoreCount;
            } else {
                return 0;
            }
        }

        /// <summary>
        /// Returns the 'review count' member from the returned data structure
        /// </summary>
        internal static int GetReviewCount (WebHeaderCollection webHeaderCollection)
        {
            int _reviewCount;
            if (int.TryParse (webHeaderCollection [HEADER_REVIEW_COUNT], out _reviewCount)) {
                return _reviewCount;
            } else {
                return 0;
            }
        }

        #endregion
    }
}
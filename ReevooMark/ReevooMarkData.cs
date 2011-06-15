using System;

namespace ReevooMark
{
    /// <summary>
    /// A structure representing a ReevooMark product review.
    /// </summary>
    /// <remarks>
    /// Any member may be empty if no data was available.
    /// </remarks>
    public struct ReevooMarkData
    {
        public String Sku { get; internal set; }
        public String Retailer { get; internal set; }
        public int ReviewCount { get; internal set; }
        public String BestPrice { get; internal set; }
        public String Content { get; internal set; }
        public int ScoreCount { get; internal set; }
        public String OverallScore { get; internal set; }
    }
}

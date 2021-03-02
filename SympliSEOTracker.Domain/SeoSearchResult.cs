
namespace SympliSEOTracker.Domain
{
    using System;
    using System.Collections.Generic;

    public class DailySeoSearchResultSet
    {
        public IEnumerable<SeoSearchResultSummary> Result { get; set; }
    }

    public class SeoSearchResultSummary
    {
        public Guid Id { get; set; }

        public DateTime SearchedOnUtc { get; set; }

        public SearchEngineType SearchEngineType { get; set; }

        public IList<SeoSearchResultCount> SeoSearchResultCountCollection { get; set; }
    }

    public class SeoSearchResultCount
    {
        /// <summary>
        /// How many result found on the page
        /// </summary>
        public int Count { get; set; }

        // 1 for Page 1
        public int PageNumber { get; set; }
    }
}

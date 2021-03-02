
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

        public List<SeoSearchResultCount> SeoSearchResultCountCollection { get; set; }

        SeoSearchResultSummary() { }

        SeoSearchResultSummary(Guid id,
            DateTime searchedOnUtc,
            SearchEngineType searchEngineType,
            List<SeoSearchResultCount> seoSearchResultCountCollection)
        {
            Id = id;
            SearchedOnUtc = searchedOnUtc;
            SearchEngineType = searchEngineType;
            SeoSearchResultCountCollection = seoSearchResultCountCollection;
        }

        public static SeoSearchResultSummary Initialise(SearchEngineType searchEngineType)
        {
            return new SeoSearchResultSummary(Guid.NewGuid(), DateTime.UtcNow, searchEngineType, new List<SeoSearchResultCount>());
        }

        public void AddSearchResult(SeoSearchResultCount seoSearchResultCount)
        {
            SeoSearchResultCountCollection.Add(seoSearchResultCount);
        }
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

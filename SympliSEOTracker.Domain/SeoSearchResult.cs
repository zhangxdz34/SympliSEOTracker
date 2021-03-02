
namespace SympliSEOTracker.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DailySeoSearchResultSet
    {
        public List<SeoSearchResultSummary> ResultCollection { get; set; }

        public bool IsUpdateRequired(DateTime currentDatetime)
        {
            if (ResultCollection == null || !ResultCollection.Any())
            {
                return true;
            }

            return ResultCollection.All(r => (currentDatetime - r.SearchedOnUtc) > TimeSpan.FromHours(1));
        }

        public void AddSearchResult(SeoSearchResultSummary searchResult)
        {
            if (ResultCollection == null)
            {
                ResultCollection = new List<SeoSearchResultSummary>();
            }

            ResultCollection.Add(searchResult);
        }
    }

    public class SeoSearchResultSummary
    {
        public Guid Id { get; set; }

        public DateTime SearchedOnUtc { get; set; }

        public SearchEngineType SearchEngineType { get; set; }

        public SeoSearchResultCount SeoSearchResultCount { get; set; }

        SeoSearchResultSummary() { }

        SeoSearchResultSummary(Guid id,
            DateTime searchedOnUtc,
            SearchEngineType searchEngineType,
            SeoSearchResultCount seoSearchResultCount)
        {
            Id = id;
            SearchedOnUtc = searchedOnUtc;
            SearchEngineType = searchEngineType;
            SeoSearchResultCount = seoSearchResultCount;
        }

        public static SeoSearchResultSummary Initialise(SearchEngineType searchEngineType)
        {
            return new SeoSearchResultSummary(Guid.NewGuid(), DateTime.UtcNow, searchEngineType, null);
        }

        public void AddSearchResult(SeoSearchResultCount seoSearchResultCount)
        {
            SeoSearchResultCount = seoSearchResultCount;
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

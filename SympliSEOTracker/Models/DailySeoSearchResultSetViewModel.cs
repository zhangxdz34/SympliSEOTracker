using SympliSEOTracker.Domain;
using System.Collections.Generic;
using System.Linq;

namespace SympliSEOTracker.Models
{
    public class DailySeoSearchResultSetViewModel
    {
        public List<DailySeoSearchResultLineItemViewModel> SearchResultLineItems { get; set; }

        public DailySeoSearchResultSetViewModel(DailySeoSearchResultSet dailySeoSearchResultSet)
        {
            SearchResultLineItems = dailySeoSearchResultSet.ResultCollection.Select(r => new DailySeoSearchResultLineItemViewModel()
            {
                SearchedOnUtc = r.SearchedOnUtc.ToString(),
                SearchEngineType = r.SearchEngineType.ToString(),
                Count = r.SeoSearchResultCount.Count
            }).ToList();
        }
    }

    public class DailySeoSearchResultLineItemViewModel
    {
        public string SearchedOnUtc { get; set; }

        public string SearchEngineType { get; set; }

        public int Count { get; set; }
    }
}

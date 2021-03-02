namespace SympliSEOTracker.Service
{
    using SympliSEOTracker.Domain;
    using SympliSEOTracker.Repository;
    using SympliSEOTracker.Repository.DataProviders;
    using System;
    using System.Threading.Tasks;

    public interface ISearchResultUpdater
    {
        Task<DailySeoSearchResultSet> UpdateSearchResultAsync(IUpdateSearchResultRequest request);
    }

    public class SearchResultUpdater : ISearchResultUpdater
    {
        private readonly ISearchResultRepository _searchResultRepository;

        public SearchResultUpdater(ISearchResultRepository searchResultRepository)
        {
            _searchResultRepository = searchResultRepository;
        }

        public async Task<DailySeoSearchResultSet> UpdateSearchResultAsync(IUpdateSearchResultRequest request)
        {
            DailySeoSearchResultSet dailySeoSearchResultSet = _searchResultRepository.GetDailySeoSearchResultSet();

            if (dailySeoSearchResultSet == null)
            {
                dailySeoSearchResultSet = new DailySeoSearchResultSet();
            }

            if (dailySeoSearchResultSet != null && !dailySeoSearchResultSet.IsUpdateRequired(DateTime.UtcNow))
            {
                return dailySeoSearchResultSet;
            }

            // Nothing cached yet. Get from search engine
            ISearchEngineReader searchEngineReader = SearchEngineReaderFactory.GetReader(request.SearchEngineType);

            SeoSearchResultSummary searchResult = await searchEngineReader.GetResultsAsync();

            dailySeoSearchResultSet.AddSearchResult(searchResult);

            _searchResultRepository.SaveDailySeoSearchResultSet(dailySeoSearchResultSet);

            return dailySeoSearchResultSet;
        }
    }
}

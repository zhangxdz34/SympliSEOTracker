using SympliSEOTracker.Domain;

namespace SympliSEOTracker.Repository
{
    public interface ISearchResultRepository
    {
        void SaveDailySeoSearchResultSet(DailySeoSearchResultSet dailySeoSearchResultSet);

        DailySeoSearchResultSet GetDailySeoSearchResultSet();
    }

    public class InMemorySearchResultRepository : GenericCachedDataProvider<DailySeoSearchResultSet>, ISearchResultRepository
    {
        private const string CacheKey = "InMemorySearchResult";

        public void SaveDailySeoSearchResultSet(DailySeoSearchResultSet dailySeoSearchResultSet)
        {
            SaveToCache(CacheKey, dailySeoSearchResultSet);
        }

        public DailySeoSearchResultSet GetDailySeoSearchResultSet()
        {
            return GetFromCache(CacheKey);
        }
    }
}

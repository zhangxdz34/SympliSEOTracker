using SympliSEOTracker.Domain;

namespace SympliSEOTracker.Repository
{
    public interface ISearchResultRepository
    {

    }
    public class InMemorySearchResultRepository : GenericCachedDataProvider<DailySeoSearchResultSet>, ISearchResultRepository
    {

    }
}

namespace SympliSEOTracker.Repository.DataProviders
{
    using SympliSEOTracker.Domain;
    using System.Threading.Tasks;

    public interface ISearchEngineReader
    {
        Task<SeoSearchResultSummary> GetResultsAsync();
    }

    public abstract class SearchEngineReader : ISearchEngineReader
    {
        protected SearchEngineReader(string searchTerm, string keyword)
        {
            SearchTerm = searchTerm;
            Keyword = keyword;
        }

        public string SearchTerm { get; set; }

        public string Keyword { get; set; }

        public int MaxResultToRead { get; set; }

        public abstract string GenerateSearchUrl();

        public abstract SearchEngineType SearchEngineType { get; }

        public abstract Task<SeoSearchResultSummary> GetResultsAsync();
    }
}

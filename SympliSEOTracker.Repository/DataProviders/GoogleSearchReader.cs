
namespace SympliSEOTracker.Repository.DataProviders
{
    using SympliSEOTracker.Domain;
    using System.Threading.Tasks;

    public class GoogleSearchReader : SearchEngineReader
    {
        public GoogleSearchReader(string searchTerm, string keyword) : base(searchTerm, keyword)
        {
        }

        public override SearchEngineType SearchEngineType
        {
            get
            {
                return SearchEngineType.Google;
            }
        }

        public override string GenerateSearchUrl()
        {
            return $"https://www.google.com/search?q={SearchTerm}&num={100}";
        }

        public override async Task<SeoSearchResultSummary> GetResultsAsync()
        {
            UrlContentReader urlContentReader = new UrlContentReader();

            SeoSearchResultSummary seoSearchResultSummary = SeoSearchResultSummary.Initialise(SearchEngineType);

            string content = await urlContentReader.GetUrlContentAsync(GenerateSearchUrl());

            if (string.IsNullOrEmpty(content))
            {
                return null;
            }

            seoSearchResultSummary.AddSearchResult(new SeoSearchResultCount() { Count = content.Split(Keyword).Length, PageNumber = 1 });

            return seoSearchResultSummary;
        }

    }
}

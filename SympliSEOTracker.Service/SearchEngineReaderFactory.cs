using SympliSEOTracker.Domain;
using SympliSEOTracker.Repository.DataProviders;
using System;

namespace SympliSEOTracker.Service
{
    public class SearchEngineReaderFactory
    {
        private static readonly string SearchTerm = "e-settlements"; // This can get from appsettings.json as well
        private static readonly string Keyword = "www.sympli.com.au"; // This can get from appsettings.json as well

        public static ISearchEngineReader GetReader(SearchEngineType searchEngineType)
        {
            if (searchEngineType == SearchEngineType.Google)
            {
                return new GoogleSearchReader(SearchTerm, Keyword);
            }

            // TODO: Implement BingSearchEngineReader

            throw new NotImplementedException($"{searchEngineType} Reader is not implemented");
        }
    }
}

using SympliSEOTracker.Domain;

namespace SympliSEOTracker.Service
{
    public interface IUpdateSearchResultRequest
    {
        SearchEngineType SearchEngineType { get; }
    }
}

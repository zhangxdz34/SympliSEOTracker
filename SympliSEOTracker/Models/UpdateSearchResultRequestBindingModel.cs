using SympliSEOTracker.Domain;
using SympliSEOTracker.Service;

namespace SympliSEOTracker.Models
{
    public class UpdateSearchResultRequestBindingModel : IUpdateSearchResultRequest
    {
        public SearchEngineType SearchEngineType
        {
            get
            {
                return SearchEngineType.Google;
            }
        }
    }
}

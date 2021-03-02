using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SympliSEOTracker.Domain;
using SympliSEOTracker.Models;
using SympliSEOTracker.Service;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SympliSEOTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchResultUpdater _searchResultUpdater;
        public HomeController(ILogger<HomeController> logger,
            ISearchResultUpdater searchResultUpdater)
        {
            _logger = logger;
            _searchResultUpdater = searchResultUpdater;
        }

        public async Task<IActionResult> Index()
        {
            DailySeoSearchResultSet result = await _searchResultUpdater.UpdateSearchResultAsync(new UpdateSearchResultRequestBindingModel());

            DailySeoSearchResultSetViewModel vm = new DailySeoSearchResultSetViewModel(result);

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

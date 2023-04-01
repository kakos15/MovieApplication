using Microsoft.AspNetCore.Mvc;
using MovieApplication.Models;
using MovieApplication.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MovieApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly OmdbApiService _omdbApiService;

        public HomeController()
        {
            _omdbApiService = OmdbApiServiceFactory.Instance;
        }

        public async Task<IActionResult> Index(string title, string year)
        {
            if (!string.IsNullOrEmpty(title))
            {
                var searchResult = await _omdbApiService.SearchMoviesAsync(title, year);
                return View("SearchResults", searchResult);
            }

            return View();
        }
        //add yesterday last one
        public async Task<IActionResult> MovieDetails(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var searchResult = await _omdbApiService.GetMovieDetailsAsync(id);
                return View("Details", searchResult);
            }

            return View();
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
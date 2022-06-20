using Aflamy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aflamy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMoviesService moviesService;

        public HomeController(ILogger<HomeController> logger, IMoviesService moviesService)
        {
            _logger = logger;
            this.moviesService = moviesService;
        }

        public IActionResult Index()
        {
            TempData["Current"] = "Index";
            IEnumerable<Movie> movies = moviesService.GetAll();
            foreach (Movie movie in movies)
            {
                moviesService.SetIsFavotite(movie.MovieID);
                movie.RateAvg = moviesService.GetAverageRate(movie.MovieID);
            }
            return View(movies);
        }
        [Authorize]
        public IActionResult ToogleToFavorites(int id)
        {
            moviesService.ToggleToFavorites(id);
            IEnumerable<Movie> movies = new List<Movie>();
            if (TempData["Current"]?.ToString() == "Favourites")
            {
                movies = moviesService.GetFavourites();
                return RedirectToAction(nameof(Favourites), movies);

            }
            else
            {
                movies = moviesService.GetAll();
                return RedirectToAction(nameof(Index), movies);
            }

        }
        [Authorize]
        public IActionResult Favourites()
        {
            List<Movie> FavMovies = moviesService.GetFavourites();
            FavMovies.ForEach(movie => movie.RateAvg = moviesService.GetAverageRate(movie.MovieID));
            TempData["Current"] = "Favourites";
            return View(FavMovies);
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

using Aflamy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aflamy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMoviesService moviesService;

        public HomeController(ILogger<HomeController> logger,IMoviesService moviesService)
        {
            _logger = logger;
            this.moviesService = moviesService;
        }

        public IActionResult Index()
        {
           IEnumerable<Movie> model=  moviesService.GetAll();
            return View(model);
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
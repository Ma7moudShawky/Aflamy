﻿using Aflamy.Models;
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
        private readonly UserManager<CustomIdentityUser> userManager;

        public HomeController(ILogger<HomeController> logger, IMoviesService moviesService, UserManager<CustomIdentityUser> userManager)
        {
            _logger = logger;
            this.moviesService = moviesService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Current"] = "Index";
            IEnumerable<Movie> movies = moviesService.GetAll();
            CustomIdentityUser user = await userManager.GetUserAsync(User);

            foreach (Movie movie in movies)
            {
                moviesService.SetIsFavotite(user, movie.MovieID);
                movie.RateAvg = moviesService.GetAverageRate(movie.MovieID);
            }
            return View(movies);
        }
        [Authorize]
        public async Task<IActionResult> ToogleToFavorites(int id)
        {
            CustomIdentityUser user = await userManager.GetUserAsync(User);
            moviesService.ToggleToFavorites(user, id);
            IEnumerable<Movie> movies = new List<Movie>();
            if (TempData.ContainsKey("Current") && TempData["Current"].ToString() == "Favourites")
            {
                movies = moviesService.GetFavourites(user);
                return RedirectToAction(nameof(Favourites), movies);

            }
            else
            {
                movies = moviesService.GetAll();
                return RedirectToAction(nameof(Index), movies);
            }

        }
        [Authorize]
        public async Task<IActionResult> Favourites()
        {
            CustomIdentityUser user = await userManager.GetUserAsync(User);
            List<Movie> FavMovies = moviesService.GetFavourites(user);
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
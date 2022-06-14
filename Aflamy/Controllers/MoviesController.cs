using Aflamy.Models;
using Aflamy.ViewModels;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aflamy.Controllers
{
    public class MoviesController : Controller
    {
        public IMoviesService MoviesService { get; }
        public ICategoryService CategoryService { get; }
        public UserManager<CustomIdentityUser> UserManager { get; }

        public MoviesController(IMoviesService moviesService, ICategoryService categoryService, UserManager<CustomIdentityUser> userManager)
        {
            MoviesService = moviesService;
            CategoryService = categoryService;
            UserManager = userManager;
        }

        // GET: Movies
        [Authorize(Roles = "Admin")]
        public IActionResult List()
        {
            var Movies = MoviesService.GetAll();
            return View(Movies);
        }

        // GET: Movies/Details/5

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (MoviesService.Get(id) == null)
            {
                return NotFound();
            }
            DetailsWithReviewViewModel detailsWithReviewViewModel = new DetailsWithReviewViewModel();
            detailsWithReviewViewModel.movie = MoviesService.Get(id);
            detailsWithReviewViewModel.movie.RateAvg = MoviesService.GetAverageRate(id);
            return View(detailsWithReviewViewModel);
        }
        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(DetailsWithReviewViewModel detailsWithReviewViewModel, int id)
        {
            CustomIdentityUser user = await UserManager.GetUserAsync(User);
            Review review = new Review()
            {
                Movie = MoviesService.Get(id),
                Rate = detailsWithReviewViewModel.review.Rate,
                ReviewBody = detailsWithReviewViewModel.review.ReviewBody,
                User = user
            };
            MoviesService.AddReview(review);
            detailsWithReviewViewModel.movie = MoviesService.Get(id);
            detailsWithReviewViewModel.movie.RateAvg = MoviesService.GetAverageRate(id);
            return View(detailsWithReviewViewModel);
        }
        // GET: Movies/Create
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            AddMovieViewModel addMovieViewModel = new AddMovieViewModel
            {
                AllCategories = CategoryService.GetAll().ToList()
            };
            return View(addMovieViewModel);
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(AddMovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = $"{DateTime.Now.ToFileTime()}{model.Posterimage.FileName}";
                model.AddedMovie.Poster = path;
                MoviesService.SaveMovieCover(model.Posterimage, path);
                model.AddedMovie.MovieCategries = CategoryService.GetCategoriesListByID(model.SelectedCategoriesIds);
                MoviesService.Add(model.AddedMovie);
                return RedirectToAction(nameof(List));
            }
            model.AllCategories = CategoryService.GetAll().ToList();
            ModelState.AddModelError("", "SomeThing wrong happened ,please try again");
            return View(model);

        }

        // GET: Movies/Edit/5
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            if (MoviesService.Get(id) == null)
            {
                return NotFound();
            }
            AddMovieViewModel addMovieViewModel = new AddMovieViewModel
            {
                AllCategories = CategoryService.GetAll().ToList()
            };
            addMovieViewModel.AddedMovie = MoviesService.Get(id);
            addMovieViewModel.SelectedCategoriesIds = addMovieViewModel.AddedMovie.MovieCategries.Select(x => x.CategoryId).ToList();

            return View(addMovieViewModel);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(AddMovieViewModel model)
        {
            ModelState.Remove("Posterimage");
            if (ModelState.IsValid)
            {
                if (model.Posterimage != null)
                {
                    string path = $"{DateTime.Now.ToFileTime()}{model.Posterimage.FileName}";
                    MoviesService.SaveMovieCover(model.Posterimage, path);
                    model.AddedMovie.Poster = path;
                }
                else
                {
                    model.AddedMovie.Poster = MoviesService.Get(model.AddedMovie.MovieID).Poster;
                }

                MoviesService.ClearMovieCategories(model.AddedMovie.MovieID);
                model.AddedMovie.MovieCategries = CategoryService.GetCategoriesListByID(model.SelectedCategoriesIds);
                MoviesService.Update(model.AddedMovie);
                return RedirectToAction(nameof(List));
            }
            model.AllCategories = CategoryService.GetAll().ToList();
            return View(model);
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (MoviesService.Get(id) == null)
            {
                return NotFound();
            }
            return View(MoviesService.Get(id));
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            MoviesService.Delete(id);
            return RedirectToAction(nameof(List));
        }


    }
}

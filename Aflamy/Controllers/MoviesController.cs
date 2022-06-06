using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aflamy.Models;
using Aflamy.ViewModels;

namespace Aflamy.Controllers
{
    public class MoviesController : Controller
    {
        public IMoviesService MoviesService { get; }
        public ICategoryService CategoryService { get; }

        public MoviesController(IMoviesService moviesService, ICategoryService categoryService)
        {
            MoviesService = moviesService;
            CategoryService = categoryService;
        }

        // GET: Movies
        public IActionResult List()
        {
            var Movies = MoviesService.GetAll();
            return View(Movies);
        }

        // GET: Movies/Details/5
        public IActionResult Details(int id)
        {
            if (MoviesService.Get(id) == null)
            {
                return NotFound();
            }

            return View(MoviesService.Get(id));
        }

        // GET: Movies/Create
        [HttpGet]
        public IActionResult Create()
        {
            AddMovieViewModel addMovieViewModel = new AddMovieViewModel();
            foreach (var category in CategoryService.GetAll())
            {
                addMovieViewModel.AllCategories.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryId.ToString() });
            }

            return View(addMovieViewModel);
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddMovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var categoryID in model.SelectedCategoriesIds)
                {
                    model.AddedMovie.MovieCategries.Add(CategoryService.Get(categoryID));
                }
                MoviesService.Add(model.AddedMovie);
                return RedirectToAction(nameof(List));
            }
            return View(model.AddedMovie);

        }

        // GET: Movies/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (MoviesService.Get(id) == null)
            {
                return NotFound();
            }

            var Updatedmovie = MoviesService.Get(id);

            return View(Updatedmovie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("MovieID,MovieName,Description,Poster")] Movie movie)
        {

            if (ModelState.IsValid)
            {
                MoviesService.Update(movie);
                return RedirectToAction(nameof(List));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
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
        public IActionResult DeleteConfirmed(int id)
        {
            MoviesService.Delete(id);
            return RedirectToAction(nameof(List));
        }

    }
}

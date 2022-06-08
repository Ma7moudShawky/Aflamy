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
            addMovieViewModel.AllCategories = CategoryService.GetSelectListItems();
            return View(addMovieViewModel);
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddMovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.AddedMovie.MovieCategries = CategoryService.GetCategoriesListByID(model.SelectedCategoriesIds);
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
            AddMovieViewModel movieViewModel = new AddMovieViewModel();
            movieViewModel.AddedMovie = MoviesService.Get(id);
            movieViewModel.AllCategories = CategoryService.GetSelectListItems();

            foreach (Category category in movieViewModel.AddedMovie.MovieCategries)
            {
                movieViewModel.AllCategories.FirstOrDefault(c => c.Text == category.CategoryName).Selected=true;
            }

            return View(movieViewModel);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AddMovieViewModel model)
        {

            //if (ModelState.IsValid)
            //{
            //    MoviesService.Update(movie);
            //    return RedirectToAction(nameof(List));
            //}
            return View(model);
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

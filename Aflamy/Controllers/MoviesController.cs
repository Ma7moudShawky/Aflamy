using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aflamy.Models;
using Aflamy.ViewModels;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Aflamy.Controllers
{
    [Authorize(Roles = "Admin")]
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
            AddMovieViewModel addMovieViewModel = new AddMovieViewModel
            {
                AllCategories = CategoryService.GetAll().ToList()
            };
            return View(addMovieViewModel);
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddMovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                string path = $"{DateTime.Now.ToFileTime()}{model.Posterimage.FileName}";
                model.AddedMovie.Poster = path;
                MoviesService.SaveMovieCover(model.Posterimage,path);
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
            foreach (Category category in addMovieViewModel.AddedMovie.MovieCategries)
            {
                addMovieViewModel.SelectedCategoriesIds.Add(category.CategoryId);
            }

            return View(addMovieViewModel);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AddMovieViewModel model)
        {
            ModelState.Remove("Posterimage");
            if (ModelState.IsValid)
            {
                if (model.Posterimage != null)
                {
                    string path = $"{DateTime.Now.ToFileTime()}{model.Posterimage.FileName}";
                    MoviesService.SaveMovieCover(model.Posterimage,path);
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

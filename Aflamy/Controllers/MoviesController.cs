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

namespace Aflamy.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MoviesController : Controller
    {
        public IMoviesService MoviesService { get; }
        public ICategoryService CategoryService { get; }
        public IWebHostEnvironment Environment { get; }

        public MoviesController(IMoviesService moviesService, ICategoryService categoryService, IWebHostEnvironment environment)
        {
            MoviesService = moviesService;
            CategoryService = categoryService;
            Environment = environment;
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
                string Fullpath = Path.Combine(Environment.WebRootPath, "Images", path);
                using (FileStream stream = new FileStream(Fullpath, FileMode.Create))
                {
                    model.Posterimage.CopyTo(stream);
                }

                model.AddedMovie.MovieCategries = CategoryService.GetCategoriesListByID(model.SelectedCategoriesIds);
                MoviesService.Add(model.AddedMovie);
                return RedirectToAction(nameof(List));
            }
            model.AllCategories = CategoryService.GetAll().ToList();
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
            string FullPath = Path.Combine(Environment.WebRootPath, "Images", addMovieViewModel.AddedMovie.Poster);
            using (var fileStream = System.IO.File.OpenRead(FullPath))
            {
                addMovieViewModel.Posterimage = new FormFile(fileStream, 0, fileStream.Length, null, Path.GetFileName(fileStream.Name));
            }
            return View(addMovieViewModel);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AddMovieViewModel model)
        {

            if (ModelState.IsValid)
            {
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

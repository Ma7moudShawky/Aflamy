using Aflamy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Aflamy.Controllers
{
    public class CategoriesController : Controller
    {
        public CategoriesController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        public ICategoryService CategoryService { get; }

        public IActionResult List()
        {
            var Categories = CategoryService.GetAll();
            return View(Categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {

                CategoryService.Add(category);
                return RedirectToAction("Details", new { id = category.CategoryId });
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(CategoryService.Get(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection _)
        {
            CategoryService.Delete(id);
            return RedirectToAction("List");
        }
        public IActionResult Details(int id)
        {
            Category category = CategoryService.Get(id);
            return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = CategoryService.Get(id);
            return View(category);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoryService.Update(category);
                return RedirectToAction("List"); ;

            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

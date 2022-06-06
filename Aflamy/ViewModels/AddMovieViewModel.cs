using Aflamy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Aflamy.ViewModels
{
    public class AddMovieViewModel
    {
        public AddMovieViewModel()
        {
            AllCategories = new List<SelectListItem>();
            SelectedCategoriesIds = new List<int>();
        }
        public List<SelectListItem> AllCategories { get; set; }
        public List<int> SelectedCategoriesIds { get; set; }
        public Movie AddedMovie { get; set; }

    }
}

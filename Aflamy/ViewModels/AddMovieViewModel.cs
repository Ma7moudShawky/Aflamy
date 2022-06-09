using Aflamy.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Aflamy.ViewModels
{
    public class AddMovieViewModel
    {
        public AddMovieViewModel()
        {
            SelectedCategoriesIds = new List<int>();
            AddedMovie=new Movie();
            AllCategories = new List<Category>();
        }

        [Required(ErrorMessage ="Please choose movie category")]
        [Display(Name ="Category")]
        public List<int> SelectedCategoriesIds { get; set; }
        public Movie AddedMovie { get; set; }
        public List<Category>? AllCategories { get; set; }

    }
}

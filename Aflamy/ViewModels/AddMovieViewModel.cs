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
            AddedMovie=new Movie();
        }

        public List<SelectListItem> AllCategories { get; set; }
        [Required(ErrorMessage ="Please choose movie category")]
        [Display(Name ="Category")]
        public List<int> SelectedCategoriesIds { get; set; }
        public Movie AddedMovie { get; set; }


    }
}

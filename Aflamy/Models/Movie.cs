﻿using System.ComponentModel.DataAnnotations;

namespace Aflamy.Models
{
    public class Movie
    {
        public Movie()
        {
            MovieCategries = new List<Category>();
        }
        public int MovieID { get; set; }
        [Required(ErrorMessage = "Please Enter Movie Name")]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }
        [Required(ErrorMessage = "Please Enter Movie Description")]
        [Display(Name = "Movie Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please Upload Movie Poster")]
        public  string Poster { get; set; }
        [Display(Name ="Categories")]
        public List<Category> MovieCategries{ get; set; }
    }
}
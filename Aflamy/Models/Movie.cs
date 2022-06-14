using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string Poster { get; set; }

        [Display(Name = "Categories")]
        public List<Category> MovieCategries { get; set; }

        public List<CustomIdentityUser>? UsersWhoFavorite { get; set; }
        [NotMapped]

        public bool? IsFavorite { get; set; }

    }
}

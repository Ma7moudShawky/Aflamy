using System.ComponentModel.DataAnnotations;

namespace Aflamy.Models
{
    public class Review
    {
        public Review()
        {
            Movie = new Movie();
            User = new CustomIdentityUser();
        }
        public int ReviewId { get; set; }
        public Movie Movie { get; set; }
        public CustomIdentityUser User { get; set; }
        [Required]
        [Range(0, 10,ErrorMessage ="The rate must be between 0 , 10")]
        public float Rate { get; set; }
        [Required(ErrorMessage ="Please Enter The Review")]
        [Display(Name = "Review")]
        public string ReviewBody { get; set; }
    }
}

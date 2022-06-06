using System.ComponentModel.DataAnnotations;

namespace Aflamy.Models
{
    public class Category
    {
        public Category()
        {
            Movies = new List<Movie>();
        }
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please Enter Category Name")]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }
        public List<Movie> Movies { get; set; }
    }
}

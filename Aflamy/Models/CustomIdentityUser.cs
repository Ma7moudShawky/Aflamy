using Microsoft.AspNetCore.Identity;

namespace Aflamy.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public CustomIdentityUser()
        {
            UserFavorites = new List<Movie>();
            Reviews = new List<Review>();
        }
        public List<Review>? Reviews { get; set; }

        public List<Movie> UserFavorites { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace Aflamy.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public CustomIdentityUser()
        {
            UserFavorites = new List<Movie>();
        }
       public List<Movie> UserFavorites { get; set; }
    }
}

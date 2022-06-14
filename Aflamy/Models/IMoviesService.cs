
namespace Aflamy.Models
{
    public interface IMoviesService
    {
        IEnumerable<Movie> GetAll();
        Movie Get(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        void ClearMovieCategories(int id);
        void SaveMovieCover(IFormFile Image, string path);
        void ToggleToFavorites(CustomIdentityUser user, int id);
        void SetIsFavotite(CustomIdentityUser User, int id);
        public List<Movie> GetFavourites(CustomIdentityUser user);

    }
}

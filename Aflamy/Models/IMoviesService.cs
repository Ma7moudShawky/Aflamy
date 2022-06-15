
using System.Security.Claims;

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
        void ToggleToFavorites(int id);
        void SetIsFavotite(int id);
        public List<Movie> GetFavourites();
        public void AddReview(Review review);
        public float GetAverageRate(int id);
    }
}

using Microsoft.EntityFrameworkCore;

namespace Aflamy.Models
{
    public class MoviesService : IMoviesService
    {
        public MoviesService(AppDBContext appDBContext, IWebHostEnvironment environment)
        {
            AppDBContext = appDBContext;
            Environment = environment;
        }

        public AppDBContext AppDBContext { get; }
        public IWebHostEnvironment Environment { get; }

        public void Add(Movie movie)
        {
            if (movie != null)
            {

                AppDBContext.Movies.Add(movie);
                AppDBContext.SaveChanges();
            };
        }

        public void Delete(int id)
        {
            var DeletedMovie = AppDBContext.Movies.FirstOrDefault(c => c.MovieID == id);
            if (DeletedMovie != null)
            {
                AppDBContext.Movies.Remove(DeletedMovie);
                AppDBContext.SaveChanges();
            }
        }

        public Movie Get(int id)
        {
            return AppDBContext.Movies
                .Include(m => m.MovieCategries)
                .Include(m => m.UsersWhoFavorite)
                .Include(m => m.Reviews)
                .ThenInclude(R => R.User)
                .FirstOrDefault(c => c.MovieID == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return AppDBContext.Movies
                .Include(m => m.MovieCategries)
                .Include(m => m.UsersWhoFavorite)
                .Include(m => m.Reviews)
                .ThenInclude(R => R.User)
                .ToList();
        }
        public void ClearMovieCategories(int id)
        {
            Movie movie = Get(id);
            movie.MovieCategries.Clear();
            AppDBContext.SaveChanges();
            var entry = AppDBContext.Entry(movie);
            entry.State = EntityState.Detached;
        }

        public void Update(Movie movie)
        {
            var entry = AppDBContext.Entry(movie);
            entry.State = EntityState.Modified;
            AppDBContext.SaveChanges();
        }

        public void SaveMovieCover(IFormFile Image, string path)
        {

            string Fullpath = Path.Combine(Environment.WebRootPath, "Images", path);
            using (FileStream stream = new FileStream(Fullpath, FileMode.Create))
            {
                Image.CopyTo(stream);
            }
        }

        public void ToggleToFavorites(CustomIdentityUser user, int id)
        {
            Movie movie = Get(id);
            if (movie.UsersWhoFavorite.Contains(user))
            {
                movie.UsersWhoFavorite.Remove(user);
            }
            else
            {
                user.UserFavorites.Add(movie);
            }
            AppDBContext.SaveChanges();
        }

        public void SetIsFavotite(CustomIdentityUser User, int id)
        {
            Movie movie = Get(id);
            if (movie.UsersWhoFavorite.Contains(User))
            {
                movie.IsFavorite = true;
            }
            else
            {
                movie.IsFavorite = false;
            }
        }
        public List<Movie> GetFavourites(CustomIdentityUser user)
        {
            List<Movie> movies = GetAll().ToList();
            List<Movie> FavMovies = movies.Where(m => m.UsersWhoFavorite.Contains(user)).ToList();
            FavMovies.ForEach(m => SetIsFavotite(user, m.MovieID));
            return FavMovies;
        }
        public void AddReview(Review review)
        {
            if (review != null)
            {
                AppDBContext.Reviews.Add(review);
                AppDBContext.SaveChanges();
            }
        }
        public float GetAverageRate(int id)
        {
            Movie movie = Get(id);
            var AllRates = movie.Reviews.Select(R => R.Rate);
            var sum = AllRates.Sum();
            if (AllRates.Count() == 0)
            {
                return 0;
            }
            double avg = sum / AllRates.Count();
            return (float)Math.Round(avg, 1);
        }
    }
}

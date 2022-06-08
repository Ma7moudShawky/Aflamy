using Microsoft.EntityFrameworkCore;

namespace Aflamy.Models
{
    public class MoviesService : IMoviesService
    {
        public MoviesService(AppDBContext appDBContext)
        {
            AppDBContext = appDBContext;
        }

        public AppDBContext AppDBContext { get; }

       

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
            return AppDBContext.Movies.Include(m=>m.MovieCategries).FirstOrDefault(c => c.MovieID == id);
        }

        public IEnumerable<Movie> GetAll()
        {
            return AppDBContext.Movies.Include(m => m.MovieCategries).ToList();
        }

        public void Update(Movie movie)
        {
            var entry = AppDBContext.Entry(movie);
            entry.State = EntityState.Modified;
            AppDBContext.SaveChanges();
        }
    }
}

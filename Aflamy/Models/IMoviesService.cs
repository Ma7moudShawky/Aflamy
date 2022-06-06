namespace Aflamy.Models
{
    public interface IMoviesService
    {
        IEnumerable<Movie> GetAll();
        Movie Get(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}

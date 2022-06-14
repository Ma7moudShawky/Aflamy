using Aflamy.Models;

namespace Aflamy.ViewModels
{
    public class DetailsWithReviewViewModel
    {
        public DetailsWithReviewViewModel()
        {
            movie = new Movie();
            review = new Review();
        }
        public Movie movie { get; set; }
        public Review review { get; set; }

    }
}

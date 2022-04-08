using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.data_access;
using ClassLibraries.models;

namespace ClassLibraries.services
{
    public static class ReviewService
    {
        private static MovieService movieService = new MovieService(new DataAccessMovie(), new DataAccessEpisode());
        public static bool PostReview(User loggedUser, int movieId, string description, int rating)
        {
            if (loggedUser == null)
            {
                throw new Exception("You are not authenticated!");
            }
            Review foundRev = DataAccessReview.GetUserReviewQuery(loggedUser.Id, movieId);
            if (foundRev != null)
            {
                throw new Exception("You have already reviewed this movie!");
            }
            if (DataAccessReview.PostReviewQuery(loggedUser.Id, movieId, description, rating))
            {
                movieService.UpdateMovieRating(movieId);
                return true;
            }
            return false;
        }
        public static Review GetReview(User loggedUser, int movieId)
        {
            return DataAccessReview.GetUserReviewQuery(loggedUser.Id, movieId);
        }
        public static List<Review> GetReviews(int userId, int movieId, int offset)
        {
            return DataAccessReview.GetReviewsQuery(userId, movieId, offset);
        }
        public static bool DeleteReview(User loggedUser, int id)
        {
            if (loggedUser == null)
            {
                throw new Exception("You are not authenticated");
            }
            if (loggedUser.IsAdmin)
            {
                return DataAccessReview.DeleteReviewQuery(id);
            }
            else
            {
                Review rev = DataAccessReview.GetReviewByIdQuery(id);
                if (rev.UserId != loggedUser.Id)
                {
                    throw new Exception("You cannot delete someone else's review");
                }
                if (DataAccessReview.DeleteReviewQuery(id))
                {
                    movieService.UpdateMovieRating(rev.MovieId);
                    return true;
                }
                return false;
            } 
        }
    }
}

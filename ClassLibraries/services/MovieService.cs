using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.data_access;
using ClassLibraries.interfaces;
using ClassLibraries.models;
using MySql.Data.MySqlClient;

namespace ClassLibraries.services
{
    public class MovieService : IMovieService
    {
        private readonly IDataAccessMovie _dataAccessMovie;
        private readonly IDataAccessEpisode dataAccessEpisode;
        public MovieService(IDataAccessMovie dataAccessMovie, IDataAccessEpisode dataAccessEpisode)
        {
            _dataAccessMovie = dataAccessMovie;
            this.dataAccessEpisode = dataAccessEpisode;
        }
        public bool AddMovie(User loggedUser, string name, string yearStr, string url, string genre, string producer, string desc, string actors, string durationStr)
        {
            DateTime year;
            TimeSpan duration;
            UserService.IsAdmin(loggedUser);
            ValidateMovie(name, genre, producer, actors, yearStr, durationStr);
            DateTime.TryParse(yearStr, out year);
            TimeSpan.TryParse(durationStr, out duration);

            return _dataAccessMovie.AddMovieQuery(name, year, url, genre, producer, desc, actors, duration);

        }
        public bool ValidateMovie(string name, string genre, string producer, string actors, string yearStr, string durationStr)
        {
            if (String.IsNullOrEmpty(name) || name.Length < 3)
            {
                throw new Exception("Name must be at least 3 characters long!");
            }
            else if (String.IsNullOrEmpty(genre))
            {
                throw new Exception("You must enter Genre");
            }
            else if (String.IsNullOrEmpty(producer))
            {
                throw new Exception("You must enter Producer");
            }
            else if (String.IsNullOrEmpty(actors))
            {
                throw new Exception("You must enter Actors");
            }
            DateTime year;
            bool s = DateTime.TryParse(yearStr, out year);
            if (!s)
            {
                throw new Exception("Date not in correct format! Use YYYY-DD-MM");
            }
            else if (year == DateTime.MinValue)
            {
                throw new Exception("You must enter a date!");
            }

            TimeSpan duration;
            s = TimeSpan.TryParse(durationStr, out duration);
            if (!s)
            {
                throw new Exception("Duration not in correct format! Use HH:MM:SS");
            }
            else if (duration == TimeSpan.Zero)
            {
                throw new Exception("You must enter duration");
            }
            return true;
        }
        public bool EditMovieOrEpisode(User loggedUser, int id, string name, string yearStr, string url, string genre, string producer, string desc, string actors, string durationStr, bool isMovie, int season, int episode)
        {
            DateTime year;
            TimeSpan duration;
            UserService.IsAdmin(loggedUser);
            ValidateMovie(name, genre, producer, actors, yearStr, durationStr);
            DateTime.TryParse(yearStr, out year);
            TimeSpan.TryParse(durationStr, out duration);

            if (isMovie)
            {
                return _dataAccessMovie.EditMovieQuery(id, name, year, url, genre, producer, desc, actors, duration);
            }
            else
            {
                return dataAccessEpisode.EditEpisodeQuery(id, name, year, url, genre, producer, desc, actors, duration, season, episode);
            }
        }
        public List<Movie> GetMovies(int offset)
        {
            return _dataAccessMovie.GetMoviesQuery(offset);
        }
        public Movie GetMovieById(int id)
        {
            return _dataAccessMovie.GetMovieByIdQuery(id);
        }

        public bool DeleteMovieOrEpisode(User loggedUser, int id)
        {
            UserService.IsAdmin(loggedUser);
            return _dataAccessMovie.DeleteMovieOrEpisodeQuery(id);

        }

        public List<Movie> SearchMovies(string keyword)
        {
            return _dataAccessMovie.SearchMoviesQuery(keyword.Trim());
        }
        public List<Movie> FilterMovies(string keyword, int yearFrom, int yearTo, int ratingMin, int ratingMax, string genre ,string sort)
        {
            DateTime yearMin;
            if (yearFrom < 1000)
            {
                yearMin = DateTime.MinValue;
            }
            else
            {
                yearMin = DateTime.Parse(yearFrom.ToString() + "-01-01");
            }
            DateTime yearMax;
            if (yearTo < 1000)
            {
                yearMax = DateTime.MaxValue;
            }
            else
            {
                yearMax = DateTime.Parse(yearTo.ToString() + "-01-01");
            }
            if (ratingMax == 0)
            {
                ratingMax = 5;
            }
            return _dataAccessMovie.FilterMoviesQuery(keyword, yearMin, yearMax, ratingMin, ratingMax, genre, sort);
        }
        public List<Movie> GetMostRatedMovies(int offset)
        {
            return _dataAccessMovie.GetMostRatedMoviesQuery(offset);
        }
        public void UpdateMovieRating(int movieId)
        {
            List<Review> reviews = DataAccessReview.GetReviewsByMovieIdQuery(movieId);
            double totalRating = 0;
            foreach (Review r in reviews)
            {
                totalRating += r.Rating;
            }
            double avgRating = totalRating / reviews.Count;
            _dataAccessMovie.EditMovieQuery(movieId, avgRating);
        }
        //FOR UNIT TESTING
        public bool DeleteLastMovie(User loggedUser)
        {
            UserService.IsAdmin(loggedUser);
            return _dataAccessMovie.DeleteLastMovieQuery();

        }
        public int GetLastMovieID(User loggedUser)
        {
            UserService.IsAdmin(loggedUser);
            return _dataAccessMovie.GetLastMovieIdQuery();
        }
        //
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.data_access;
using ClassLibraries.models;
using MySql.Data.MySqlClient;

namespace ClassLibraries.services
{
    public static class MovieService
    {
        private static MySqlConnection conn = new MySqlConnection(Utils.conString);
        public static bool AddMovie(string name, string yearStr, string url, string genre, string producer, string desc, string actors, string durationStr)
        {
            DateTime year;
            TimeSpan duration;

            ValidateMovie(name, genre, producer, actors, yearStr, durationStr);
            DateTime.TryParse(yearStr, out year);
            TimeSpan.TryParse(durationStr, out duration);

            return DataAccessMovie.AddMovieQuery(name, year, url, genre, producer, desc, actors, duration);

        }
        public static bool ValidateMovie(string name, string genre, string producer, string actors, string yearStr, string durationStr)
        {
            if (!UserService.loggedUser.IsAdmin)
            {
                throw new Exception("You are not authorized!");
            }
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
        public static bool EditMovieOrEpisode(int id, string name, string yearStr, string url, string genre, string producer, string desc, string actors, string durationStr, bool isMovie, int season, int episode)
        {
            DateTime year;
            TimeSpan duration;
            ValidateMovie(name, genre, producer, actors, yearStr, durationStr);
            DateTime.TryParse(yearStr, out year);
            TimeSpan.TryParse(durationStr, out duration);

            if (isMovie)
            {
                return DataAccessMovie.EditMovieQuery(id, name, year, url, genre, producer, desc, actors, duration);
            }
            else
            {
                return DataAccessEpisode.EditEpisodeQuery(id, name, year, url, genre, producer, desc, actors, duration, season, episode);
            }
        }
        public static List<Movie> GetMovies(int offset)
        {
            return DataAccessMovie.GetMoviesQuery(offset);
        }
        public static Movie GetMovieById(int id)
        {
            return DataAccessMovie.GetMovieByIdQuery(id);
        }

        public static bool DeleteMovieOrEpisode(int id)
        {
            if (!UserService.loggedUser.IsAdmin)
            {
                throw new Exception("You are not authorized!");
            }
            return DataAccessMovie.DeleteMovieOrEpisodeQuery(id);

        }

        public static List<Movie> SearchMovies(string keyword)
        {
            return DataAccessMovie.SearchMoviesQuery(keyword.Trim());
        }

        //FOR UNIT TESTING
        public static bool DeleteLastMovie()
        {
            if (!UserService.loggedUser.IsAdmin)
            {
                throw new Exception("You are not authorized!");
            }
            return DataAccessMovie.DeleteLastMovieQuery();

        }
        public static int GetLastMovieID()
        {
            if (!UserService.loggedUser.IsAdmin)
            {
                throw new Exception("You are not authorized!");
            }
            return DataAccessMovie.GetLastMovieIdQuery();
        }
        //
    }
}

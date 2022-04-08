using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.models;

namespace ClassLibraries.interfaces
{
    public interface IMovieService
    {
        public bool AddMovie(User loggedUser, string name, string yearStr, string url, string genre, string producer, string desc, string actors, string durationStr);
        public bool ValidateMovie(string name, string genre, string producer, string actors, string yearStr, string durationStr);
        public bool EditMovieOrEpisode(User loggedUser, int id, string name, string yearStr, string url, string genre, string producer, string desc, string actors, string durationStr, bool isMovie, int season, int episode);
        public List<Movie> GetMovies(int offset);
        public Movie GetMovieById(int id);

        public bool DeleteMovieOrEpisode(User loggedUser, int id);

        public List<Movie> SearchMovies(string keyword);
        public List<Movie> FilterMovies(string keyword, int yearFrom, int yearTo, int ratingMin, int ratingMax, string genre, string sort);
        public List<Movie> GetMostRatedMovies(int offset);
        public void UpdateMovieRating(int movieId);
        public bool DeleteLastMovie(User loggedUser);
        public int GetLastMovieID(User loggedUser);
    }
}

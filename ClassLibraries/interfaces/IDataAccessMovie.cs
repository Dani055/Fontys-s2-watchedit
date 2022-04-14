using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.models;

namespace ClassLibraries.interfaces
{
    public interface IDataAccessMovie
    {
        public bool AddMovie(string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration);


        public bool EditMovie(int id, double rating);

        public bool EditMovie(int id, string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration);

        public List<Movie> GetMovies(int offset);

        public Movie GetMovieById(int id);

        public bool DeleteMovieOrEpisode(int id);

        public List<Movie> SearchMovies(string keyword);

        public List<Movie> FilterMovies(string keyword, DateTime yearFrom, DateTime yearTo, int ratingMin, int ratingMax, string genreLike, string sort);

        public List<Movie> GetMostRatedMovies(int offset);


        public bool DeleteLastMovie();

        public int GetLastMovieId();
        
    }
}

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
        public bool AddMovieQuery(string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration);


        public bool EditMovieQuery(int id, double rating);

        public bool EditMovieQuery(int id, string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration);

        public List<Movie> GetMoviesQuery(int offset);

        public Movie GetMovieByIdQuery(int id);

        public bool DeleteMovieOrEpisodeQuery(int id);

        public List<Movie> SearchMoviesQuery(string keyword);

        public List<Movie> FilterMoviesQuery(string keyword, DateTime yearFrom, DateTime yearTo, int ratingMin, int ratingMax, string genreLike, string sort);

        public List<Movie> GetMostRatedMoviesQuery(int offset);


        public bool DeleteLastMovieQuery();

        public int GetLastMovieIdQuery();
        
    }
}

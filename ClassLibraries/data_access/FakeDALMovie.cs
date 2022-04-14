using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.interfaces;
using ClassLibraries.models;

namespace ClassLibraries.data_access
{
    public class FakeDALMovie : IDataAccessMovie
    {
        private List<Movie> movies = new List<Movie>()
        {
            new Movie(1, "Incredibles", DateTime.Parse("2002-02-02"), "url", "Animation", "Someone", "Description", "Actors", TimeSpan.Parse("1:52:00"), 4),
            new Movie(2, "Witcher", DateTime.Parse("2019-02-02"), "url", "Medieval", "Polish prod", "Description", "Actors", TimeSpan.Parse("0:59:00"), 5),
            new Movie(3, "Spiderman", DateTime.Parse("1998-01-01"), "url", "Action", "Producer", "Description", "Actors", TimeSpan.Parse("1:39:00"), 0),
            new Movie(3, "Iron Man", DateTime.Parse("2008-01-01"), "url", "Action", "Producer", "Description", "Actors", TimeSpan.Parse("1:48:00"), 3)
        };
        private static int id = 3;
        public bool AddMovie(string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration)
        {
            movies.Add(new Movie(id += 1, name, year, url, genre, producer, desc, actors, duration, 0));
            return true;
        }

        public bool DeleteLastMovie()
        {
            throw new NotImplementedException();
        }

        public bool DeleteMovieOrEpisode(int id)
        {
            foreach (Movie m in movies)
            {
                if (m.Id == id)
                {
                    movies.Remove(m);
                    break;
                }
            }
            return true;
        }

        public bool EditMovie(int id, double rating)
        {
            foreach (Movie m in movies)
            {
                if (m.Id == id)
                {
                    m.Rating = rating;
                    break;
                }
            }
            return true;
        }

        public bool EditMovie(int id, string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration)
        {
            foreach (Movie m in movies)
            {
                if (m.Id == id)
                {
                    m.Name = name;
                    m.Year = year;
                    m.ImageUrl = url;
                    m.Genre = genre;
                    m.Producer = producer;
                    m.Description = desc;
                    m.Actors = actors;
                    m.Duration = duration;
                    break;
                }
            }
            return true;
        }

        public List<Movie> FilterMovies(string keyword, DateTime yearFrom, DateTime yearTo, int ratingMin, int ratingMax, string genreLike, string sort)
        {
            throw new NotImplementedException();
        }

        public int GetLastMovieId()
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetMostRatedMovies(int offset)
        {
            return movies;
        }

        public Movie GetMovieById(int id)
        {
            foreach (Movie m in movies)
            {
                if (m.Id == id)
                {
                    return m;
                }
            }
            return null;
        }

        public List<Movie> GetMovies(int offset)
        {
            return movies;
        }

        public List<Movie> SearchMovies(string keyword)
        {
            return movies;
        }
    }
}

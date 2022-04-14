using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.interfaces;
using ClassLibraries.models;
using MySql.Data.MySqlClient;

namespace ClassLibraries.data_access
{
    public class DataAccessMovie : IDataAccessMovie
    {
        private readonly IDBSettings dBSettings;
        public DataAccessMovie(IDBSettings dbsettings)
        {
            dBSettings = dbsettings;
        }
        public bool AddMovie(string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration)
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"INSERT INTO {dBSettings.MovieTable()} (name, year, imageUrl, genre, producer, description, actors, duration) VALUES(@name, @year, @imageUrl, @genre, @producer, @description, @actors, @duration); ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@year", year.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@imageUrl", url);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@producer", producer);
                cmd.Parameters.AddWithValue("@description", desc);
                cmd.Parameters.AddWithValue("@actors", actors);
                cmd.Parameters.AddWithValue("@duration", duration);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool EditMovie(int id, double rating)
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"UPDATE {dBSettings.MovieTable()} SET rating = @rating WHERE id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@rating", rating);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                conn.Close();
            }

        }
        public bool EditMovie(int id, string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration)
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"UPDATE {dBSettings.MovieTable()} SET name = @name, year = @year, imageUrl = @imageUrl, genre = @genre, description = @description, producer = @producer, actors = @actors, duration = @duration WHERE id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@year", year.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@imageUrl", url);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@producer", producer);
                cmd.Parameters.AddWithValue("@description", desc);
                cmd.Parameters.AddWithValue("@actors", actors);
                cmd.Parameters.AddWithValue("@duration", duration);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return true;
            }
            finally{
                conn.Close();
            }
            
        }
        public List<Movie> GetMovies(int offset)
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"SELECT * FROM {dBSettings.MovieTable()} where seriesId is NULL ORDER BY id DESC LIMIT 4 OFFSET @offset";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@offset", offset);
                List<Movie> movies = new List<Movie>();
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");
                    DateTime year = DateTime.Parse(reader.GetString("year"));
                    string url = reader["imageUrl"].ToString();
                    string genre = reader.GetString("genre");
                    string producer = reader["producer"].ToString();
                    string desc = reader["description"].ToString();
                    string actors = reader["actors"].ToString();
                    TimeSpan duration = TimeSpan.Parse(reader["duration"].ToString());
                    double rating = reader.GetDouble("rating");

                    Movie m = new Movie(id, name, year, url, genre, producer, desc, actors, duration, rating);
                    movies.Add(m);

                }
                reader.Close();
                return movies;
            }
            finally
            {
                conn.Close();
            }
        }
        public Movie GetMovieById(int id)
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"Select * from {dBSettings.MovieTable()} WHERE id = @ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                Movie m;

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int Id = reader.GetInt32("id");
                    string name = reader.GetString("name");
                    DateTime year = DateTime.Parse(reader.GetString("year"));
                    string url = reader["imageUrl"].ToString();
                    string genre = reader.GetString("genre");
                    string producer = reader["producer"].ToString();
                    string desc = reader["description"].ToString();
                    string actors = reader["actors"].ToString();
                    TimeSpan duration = TimeSpan.Parse(reader["duration"].ToString());
                    double rating = reader.GetDouble("rating");
                    string seriesId = reader["seriesId"].ToString();
                    if (seriesId != null && seriesId != "")
                    {
                        throw new Exception("Trying to get movie but object is an episode.");
                    }
                    m = new Movie(Id, name, year, url, genre, producer, desc, actors, duration, rating);
                    return m;
                }
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool DeleteMovieOrEpisode(int id)
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"DELETE FROM {dBSettings.MovieTable()} WHERE id = @ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return true;

            }
            finally
            {
                conn.Close();
            }
        }
        public List<Movie> SearchMovies(string keyword)
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"SELECT * FROM {dBSettings.MovieTable()} where seriesId is NULL and name like @keyword";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                List<Movie> movies = new List<Movie>();
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");
                    DateTime year = DateTime.Parse(reader.GetString("year"));
                    string url = reader["imageUrl"].ToString();
                    string genre = reader.GetString("genre");
                    string producer = reader["producer"].ToString();
                    string desc = reader["description"].ToString();
                    string actors = reader["actors"].ToString();
                    TimeSpan duration = TimeSpan.Parse(reader["duration"].ToString());
                    double rating = reader.GetDouble("rating");

                    Movie m = new Movie(id, name, year, url, genre, producer, desc, actors, duration, rating);
                    movies.Add(m);

                }
                reader.Close();
                return movies;
            }
            finally
            {
                conn.Close();
            }
        }
        public List<Movie> FilterMovies(string keyword, DateTime yearFrom, DateTime yearTo, int ratingMin, int ratingMax,string genreLike, string sort)
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"SELECT * FROM {dBSettings.MovieTable()} where seriesId is null and year >= @yearFrom and year <= @yearTo and rating >= @ratingMin and rating <= @ratingMax and genre like @genre and (name like @keyword or description like @keyword) " + sort;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@yearFrom", yearFrom.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@yearTo", yearTo.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ratingMin", ratingMin);
                cmd.Parameters.AddWithValue("@ratingMax", ratingMax);
                cmd.Parameters.AddWithValue("@genre", "%" + genreLike + "%");
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                List<Movie> movies = new List<Movie>();
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");
                    DateTime year = DateTime.Parse(reader.GetString("year"));
                    string url = reader["imageUrl"].ToString();
                    string genre = reader.GetString("genre");
                    string producer = reader["producer"].ToString();
                    string desc = reader["description"].ToString();
                    string actors = reader["actors"].ToString();
                    TimeSpan duration = TimeSpan.Parse(reader["duration"].ToString());
                    double rating = reader.GetDouble("rating");

                    Movie m = new Movie(id, name, year, url, genre, producer, desc, actors, duration, rating);
                    movies.Add(m);

                }
                reader.Close();
                return movies;
            }
            finally
            {
                conn.Close();
            }
        }
        public List<Movie> GetMostRatedMovies(int offset)
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"SELECT * FROM {dBSettings.MovieTable()} where seriesId is NULL ORDER BY rating desc LIMIT 4 OFFSET @offset";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@offset", offset);
                List<Movie> movies = new List<Movie>();
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");
                    DateTime year = DateTime.Parse(reader.GetString("year"));
                    string url = reader["imageUrl"].ToString();
                    string genre = reader.GetString("genre");
                    string producer = reader["producer"].ToString();
                    string desc = reader["description"].ToString();
                    string actors = reader["actors"].ToString();
                    TimeSpan duration = TimeSpan.Parse(reader["duration"].ToString());
                    double rating = reader.GetDouble("rating");

                    Movie m = new Movie(id, name, year, url, genre, producer, desc, actors, duration, rating);
                    movies.Add(m);

                }
                reader.Close();
                return movies;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool DeleteLastMovie()
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"delete from {dBSettings.MovieTable()} order by id desc limit 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return true;

            }
            finally
            {
                conn.Close();
            }
        }
        public int GetLastMovieId()
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"SELECT MAX(ID) FROM {dBSettings.MovieTable()}";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int id = reader.GetInt32("MAX(ID)");
                return id;

            }
            finally
            {
                conn.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.models;
using MySql.Data.MySqlClient;

namespace ClassLibraries.data_access
{
    public static class DataAccessMovie
    {
        public static bool AddMovieQuery(string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "INSERT INTO movie (name, year, imageUrl, genre, producer, description, actors, duration) VALUES(@name, @year, @imageUrl, @genre, @producer, @description, @actors, @duration); ";
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

        public static bool EditMovieQuery(int id, string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "UPDATE movie SET name = @name, year = @year, imageUrl = @imageUrl, genre = @genre, description = @description, producer = @producer, actors = @actors, duration = @duration WHERE id = @id;";
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
        public static List<Movie> GetMoviesQuery(int offset)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "SELECT * FROM watchedit_movies_view LIMIT 4 OFFSET @offset";
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
                    int rating = reader.GetInt16("rating");

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
        public static Movie GetMovieByIdQuery(int id)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "Select * from watchedit_movies_view WHERE id = @ID";
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
                    int rating = reader.GetInt16("rating");
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
        public static bool DeleteMovieOrEpisodeQuery(int id)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "DELETE FROM movie WHERE id = @ID";
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
        public static List<Movie> SearchMoviesQuery(string keyword)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "SELECT * FROM watchedit_movies_view where name like @keyword";
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
                    int rating = reader.GetInt16("rating");

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
        public static bool DeleteLastMovieQuery()
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "delete from Movie order by id desc limit 1";
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
        public static int GetLastMovieIdQuery()
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "SELECT MAX(ID) FROM Movie";
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

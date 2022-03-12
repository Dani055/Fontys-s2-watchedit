using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.models;
using MySql.Data.MySqlClient;

namespace ClassLibraries.services
{
    public static class MovieService
    {
        private static MySqlConnection conn = new MySqlConnection(Utils.conString);
        public static bool AddMovie(string name, string yearStr, string url, string genre, string producer, string desc, string actors, string durationStr)
        {
            try
            {
                DateTime year;
                TimeSpan duration;
                ValidateMovie(name, genre, producer, actors, yearStr, durationStr);
                DateTime.TryParse(yearStr, out year);
                TimeSpan.TryParse(durationStr, out duration);

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
        public static bool ValidateMovie(string name, string genre, string producer, string actors, string yearStr, string durationStr)
        {
            if (!UserService.loggedUser.IsAdmin)
            {
                throw new Exception("You are not authorized!");
            }
            if (name.Length < 3)
            {
                throw new Exception("Name must be at least 3 characters long!");
            }
            else if (genre == "")
            {
                throw new Exception("You must enter Genre");
            }
            else if (producer == "")
            {
                throw new Exception("You must enter Producer");
            }
            else if (actors == "")
            {
                throw new Exception("You must enter Actors");
            }
            DateTime year;
            bool s = DateTime.TryParse(yearStr, out year);
            if (!s)
            {
                throw new Exception("Date not in correct format! Use YYYY-DD-MM");
            }

            TimeSpan duration;
            s = TimeSpan.TryParse(durationStr, out duration);
            if (!s)
            {
                throw new Exception("Duration not in correct format! Use HH:MM:SS");
            }
            return true;
        }
        public static bool EditMovieOrEpisode(int id, string name, string yearStr, string url, string genre, string producer, string desc, string actors, string durationStr, bool isMovie, int season, int episode)
        {
            try
            {
                DateTime year;
                TimeSpan duration;
                ValidateMovie(name, genre, producer, actors, yearStr, durationStr);
                DateTime.TryParse(yearStr, out year);
                TimeSpan.TryParse(durationStr, out duration);

                string sql;
                if (isMovie)
                {
                    sql = "UPDATE movie SET name = @name, year = @year, imageUrl = @imageUrl, genre = @genre, description = @description, producer = @producer, actors = @actors, duration = @duration WHERE id = @id;";
                }
                else
                {
                    sql = "UPDATE movie SET name = @name, year = @year, imageUrl = @imageUrl, genre = @genre, description = @description, producer = @producer, actors = @actors, duration = @duration, season = @season, episode = @episode WHERE id = @id;";
                }

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
                if (!isMovie)
                {
                    cmd.Parameters.AddWithValue("@season", season);
                    cmd.Parameters.AddWithValue("@episode", episode);
                }
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                conn.Close();
            }
        }
        public static List<Movie> GetMovies(int offset)
        {
            try
            {
                string sql = "SELECT * FROM movie where seriesId is NULL ORDER BY id desc LIMIT 4 OFFSET @offset";
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

                    Movie m = new Movie(id, name, year, url, genre, producer, desc, actors, duration);
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
        public static Movie GetMovieById(int id)
        {
            try
            {
                string sql = "Select * from movie WHERE id = @ID";
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
                    string seriesId = reader["seriesId"].ToString();
                    if (seriesId != null && seriesId != "")
                    {
                        throw new Exception("Trying to get movie but object is an episode.");
                    }
                    m = new Movie(Id, name, year, url, genre, producer, desc, actors, duration);
                    return m;
                }
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool DeleteMovieOrEpisode(int id)
        {
            try
            {
                if (!UserService.loggedUser.IsAdmin)
                {
                    throw new Exception("You are not authorized!");
                }

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
        public static List<Movie> SearchMovies(string keyword)
        {
            try
            {
                string sql = "SELECT * FROM movie where seriesId is NULL and name like @keyword";
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

                    Movie m = new Movie(id, name, year, url, genre, producer, desc, actors, duration);
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
    }
}

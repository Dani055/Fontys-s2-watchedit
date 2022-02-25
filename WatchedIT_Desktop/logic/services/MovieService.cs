using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WatchedIT_Desktop.logic.models;

namespace WatchedIT_Desktop.logic.services
{
    public static class MovieService
    {
        private static MySqlConnection conn = new MySqlConnection(Utils.conString);
        public static bool AddMovie(string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration)
        {
            if (name.Length < 3)
            {
                MessageBox.Show("Name must be at least 3 characters long!");
                return false;
            }
            else if (genre == "")
            {
                MessageBox.Show("You must enter Genre");
                return false;
            }
            else if (producer == "")
            {
                MessageBox.Show("You must enter Producer");
                return false;
            }
            else if (actors == "")
            {
                MessageBox.Show("You must enter Actors");
                return false;
            }

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
                MessageBox.Show("Movie added successfully");
                conn.Close();   
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public static List<Movie> GetMovies()
        {
            try
            {
                string sql = "SELECT * FROM movie where seriesId is NULL";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                List<Movie> movies = new List<Movie>();
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");
                    DateTime year = DateTime.Parse(reader.GetString("year"));
                    string url = reader.GetString("imageUrl");
                    string genre = reader.GetString("genre");
                    string producer = reader["producer"].ToString();
                    string desc = reader["description"].ToString();
                    string actors = reader["actors"].ToString();
                    TimeSpan duration = TimeSpan.Parse(reader["duration"].ToString());

                    Movie m = new Movie(id, name, year, url, genre, producer, desc, actors, duration);
                    movies.Add(m);

                }
                reader.Close();
                conn.Close();
                return movies;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                throw;
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
                    string url = reader.GetString("imageUrl");
                    string genre = reader.GetString("genre");
                    string producer = reader["producer"].ToString();
                    string desc = reader["description"].ToString();
                    string actors = reader["actors"].ToString();
                    TimeSpan duration = TimeSpan.Parse(reader["duration"].ToString());
                    m = new Movie(Id, name, year, url, genre, producer, desc, actors, duration);
                    conn.Close();
                    return m;
                }
                conn.Close();
                return null;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                throw;
            }

         }

        public static bool DeleteMovieOrEpisode(int id)
        {
            try
            {
                string sql = "DELETE FROM movie WHERE id = @ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                {
                    MessageBox.Show("Movie deleted successfully!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Something went wrong!");
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                throw;
            }

        }
    }
}

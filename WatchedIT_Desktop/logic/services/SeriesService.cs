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
    class SeriesService
    {
        private static MySqlConnection conn = new MySqlConnection(Utils.conString);

        public static bool AddSeries(string name, DateTime year, string url, string genre, string desc, string actors, string producer)
        {
            if (!UserService.loggedUser.IsAdmin)
            {
                MessageBox.Show("You are not authorized!");
                return false;
            }
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

            try
            {
                string sql = "INSERT INTO series (name, year, imageUrl, genre, description, actors, producer) VALUES (@name, @year, @imageUrl, @genre, @description, @actors, @producer);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@year", year.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@imageUrl", url);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@description", desc);
                cmd.Parameters.AddWithValue("@actors", actors);
                cmd.Parameters.AddWithValue("@producer", producer); ;

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                MessageBox.Show("Series added successfully");
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
        public static bool EditSeries(int id, string name, DateTime year, string url, string genre, string desc, string actors, string producer)
        {
            if (!UserService.loggedUser.IsAdmin)
            {
                MessageBox.Show("You are not authorized!");
                return false;
            }
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

            try
            {
                string sql = "UPDATE series SET name = @name, year = @year, imageUrl = @imageUrl, genre = @genre, description = @description, producer = @producer, actors = @actors WHERE id = @id;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@year", year.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@imageUrl", url);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@description", desc);
                cmd.Parameters.AddWithValue("@actors", actors);
                cmd.Parameters.AddWithValue("@producer", producer);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                MessageBox.Show("Series edited successfully");
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
        public static List<Series> GetSeries(int offset)
        {
            try
            {
                string sql = "SELECT * FROM series ORDER BY id desc LIMIT 4 OFFSET @offset";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@offset", offset);
                List<Series> series = new List<Series>();
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");
                    DateTime year = DateTime.Parse(reader.GetString("year"));
                    string url = reader["imageUrl"].ToString();
                    string genre = reader.GetString("genre");
                    string desc = reader["description"].ToString();
                    string actors = reader["actors"].ToString();
                    string producer = reader["producer"].ToString();

                    Series s = new Series(id, name, year, url, genre, producer, desc, actors);
                    series.Add(s);

                }
                reader.Close();
                conn.Close();
                return series;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        public static List<Series> SearchSeries(string keyword)
        {
            try
            {
                string sql = "SELECT * FROM series WHERE name like @keyword";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                List<Series> series = new List<Series>();
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");
                    DateTime year = DateTime.Parse(reader.GetString("year"));
                    string url = reader["imageUrl"].ToString();
                    string genre = reader.GetString("genre");
                    string desc = reader["description"].ToString();
                    string actors = reader["actors"].ToString();
                    string producer = reader["producer"].ToString();

                    Series s = new Series(id, name, year, url, genre, producer, desc, actors);
                    series.Add(s);

                }
                reader.Close();
                conn.Close();
                return series;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        public static Series GetSeriesById(int id)
        {
            try
            {
                string sql = "Select * from series WHERE id = @ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                Series s;

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

                    s = new Series(Id, name, year, url, genre, producer, desc, actors);
                    conn.Close();
                    return s;
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

        public static bool DeleteSeries(int id)
        {
            if (!UserService.loggedUser.IsAdmin)
            {
                MessageBox.Show("You are not authorized!");
                return false;
            }
            try
            {
                string sql = "DELETE FROM series WHERE id = @ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                {
                    MessageBox.Show("Series deleted successfully!");
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

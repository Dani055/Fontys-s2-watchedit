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

        public static bool AddSeries(string name, DateTime year, string url, string genre, string desc)
        {
            if (name.Length < 3)
            {
                MessageBox.Show("Name must be at least 3 characters long!");
                return false;
            }
            else if (url == "")
            {
                MessageBox.Show("You must enter URL");
                return false;
            }
            else if (genre == "")
            {
                MessageBox.Show("You must enter Genre");
                return false;
            }

            try
            {
                string sql = "INSERT INTO series (name, year, imageUrl, genre, description) VALUES (@name, @year, @imageUrl, @genre, @description);";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@year", year.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@imageUrl", url);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@description", desc);


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

        public static List<Series> GetSeries()
        {
            try
            {
                string sql = "SELECT * FROM series";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
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

                    Series s = new Series(id, name, year, url, genre, desc);
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
    }
}

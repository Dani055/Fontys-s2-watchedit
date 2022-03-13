using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.models;
using MySql.Data.MySqlClient;

namespace ClassLibraries.services
{
    public class SeriesService
    {
        private static MySqlConnection conn = new MySqlConnection(Utils.conString);

        public static bool AddSeries(string name, string yearStr, string url, string genre, string desc, string actors, string producer)
        {
            try
            {
                DateTime year;
                ValidateSeries(name, genre,producer, actors, yearStr);
                DateTime.TryParse(yearStr, out year);

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
                return true;
            }
            finally
            {
                conn.Close();
            }
        }
        public static bool EditSeries(int id, string name, string yearStr, string url, string genre, string desc, string actors, string producer)
        {
            try
            {
                DateTime year;
                ValidateSeries(name, genre, producer, actors, yearStr);
                DateTime.TryParse(yearStr, out year);

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
                return true;
            }
            finally
            {
                conn.Close();
            }
        }
        public static bool ValidateSeries(string name, string genre, string producer, string actors, string yearStr)
        {
            if (!UserService.loggedUser.IsAdmin)
            {
                throw new Exception("You are not authorized!");
            }
            if (String.IsNullOrEmpty (name) || name.Length < 3)
            {
                throw new Exception("Name must be at least 3 characters long!");
            }
            else if (String.IsNullOrEmpty(genre))
            {
                throw new Exception("You must enter Genre");
            }
            else if (String.IsNullOrEmpty(producer))
            {
                throw new Exception("You must enter a producer");
            }
            else if (String.IsNullOrEmpty(actors))
            {
                throw new Exception("You must enter actors");
            }
            DateTime year;
            bool s = DateTime.TryParse(yearStr, out year);
            if (!s)
            {
                throw new Exception("Date not in correct format! Use YYYY-DD-MM");
            }
            else if (year == DateTime.MinValue)
            {
                throw new Exception("You must enter a date.");
            }
            return true;
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
                return series;
            }
            finally
            {
                conn.Close();
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
                return series;
            }
            finally
            {
                conn.Close();
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
                    return s;
                }
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool DeleteSeries(int id)
        {
            try
            {
                if (!UserService.loggedUser.IsAdmin)
                {
                    throw new Exception("You are not authorized!");
                }
                string sql = "DELETE FROM series WHERE id = @ID";
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
    }
}

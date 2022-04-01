using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.models;
using MySql.Data.MySqlClient;

namespace ClassLibraries.data_access
{
    public static class DataAccessSeries
    {

        public static bool AddSeriesQuery(string name, DateTime year, string url, string genre, string desc, string actors, string producer)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
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
                return true;
            }
            finally
            {
                conn.Close();
            }
        }
        public static bool EditSeriesQuery(int id, string name, DateTime year, string url, string genre, string desc, string actors, string producer)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
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
                return true;
            }
            finally
            {
                conn.Close();
            }
        }
        public static List<Series> GetSeriesQuery(int offset)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "SELECT * FROM watchedit_series_view LIMIT 4 OFFSET @offset";
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
        public static List<Series> SearchSeriesQuery(string keyword)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "SELECT * FROM watchedit_series_view WHERE name like @keyword";
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
        public static Series GetSeriesByIdQuery(int id)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "Select * from watchedit_series_view WHERE id = @ID";
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
        public static bool DeleteSeriesQuery(int id)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {

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
        public static bool DeleteLastSeriesQuery()
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                
                string sql = "delete from Series order by id desc limit 1";
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
        public static int GetLastSeriesIdQuery()
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {

                string sql = "SELECT MAX(ID) FROM Series";
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

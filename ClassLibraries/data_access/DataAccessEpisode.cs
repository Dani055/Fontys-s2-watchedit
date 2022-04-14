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
    public class DataAccessEpisode : IDataAccessEpisode
    {
        private readonly IDBSettings dBSettings;
        public DataAccessEpisode(IDBSettings dbsettings)
        {
            dBSettings = dbsettings;
        }
        public bool AddEpisode(string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration, int season, int episode, int seriesId)
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"INSERT INTO {dBSettings.MovieTable()} (name, year, imageUrl, genre, producer, description, actors, duration, season, episode, seriesId) VALUES(@name, @year, @imageUrl, @genre, @producer, @description, @actors, @duration, @season, @episode, @seriesId); ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@year", year.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@imageUrl", url);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@producer", producer);
                cmd.Parameters.AddWithValue("@description", desc);
                cmd.Parameters.AddWithValue("@actors", actors);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@season", season);
                cmd.Parameters.AddWithValue("@episode", episode);
                cmd.Parameters.AddWithValue("@seriesId", seriesId);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool EditEpisode(int id, string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration, int season, int episode)
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"UPDATE {dBSettings.MovieTable()} SET name = @name, year = @year, imageUrl = @imageUrl, genre = @genre, description = @description, producer = @producer, actors = @actors, duration = @duration, season = @season, episode = @episode WHERE id = @id;";

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
                cmd.Parameters.AddWithValue("@season", season);
                cmd.Parameters.AddWithValue("@episode", episode);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                conn.Close();
            }
        }
        public List<Episode> GetEpisodes(int seriesid)
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"SELECT * FROM {dBSettings.MovieTable()} WHERE seriesId = @seriesId";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@seriesId", seriesid);
                List<Episode> episodes = new List<Episode>();

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
                    TimeSpan duration = TimeSpan.Parse(reader["duration"].ToString());
                    double rating = reader.GetDouble("rating");
                    int season = int.Parse(reader["season"].ToString());
                    int episode = int.Parse(reader["episode"].ToString());
                    int seriesId = int.Parse(reader["episode"].ToString());

                    Episode e = new Episode(id, name, year, url, genre, producer, desc, actors, duration, rating, seriesId, season, episode);
                    episodes.Add(e);

                }
                reader.Close();
                return episodes;
            }
            finally
            {
                conn.Close();
            }
        }
        public Episode GetEpisodeById(int id)
        {
            MySqlConnection conn = new MySqlConnection(dBSettings.GetConString());
            try
            {
                string sql = $"Select * from {dBSettings.MovieTable()} where id = @ID";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                Episode e;

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
                    bool res;
                    int seriesId;
                    res = int.TryParse(reader["seriesId"].ToString(), out seriesId);
                    if (!res)
                    {
                        throw new Exception("Trying to get episode, but object is a movie");
                    }
                    int episode = int.Parse(reader["episode"].ToString());
                    int season = int.Parse(reader["season"].ToString());

                    e = new Episode(Id, name, year, url, genre, producer, desc, actors, duration, rating, seriesId, season, episode);
                    return e;
                }
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

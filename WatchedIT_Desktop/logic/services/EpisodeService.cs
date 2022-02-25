﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WatchedIT_Desktop.logic.models;

namespace WatchedIT_Desktop.logic.services
{
    public static class EpisodeService
    {
        private static MySqlConnection conn = new MySqlConnection(Utils.conString);

        public static bool AddEpisode(string name, DateTime year, string url, string genre, string producer, string desc, string actors, TimeSpan duration, int season, int episode, int seriesId)
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
                string sql = "INSERT INTO movie (name, year, imageUrl, genre, producer, description, actors, duration, season, episode, seriesId) VALUES(@name, @year, @imageUrl, @genre, @producer, @description, @actors, @duration, @season, @episode, @seriesId); ";
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
                MessageBox.Show("Episode added successfully");
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

        public static List<Episode> GetEpisodes(int seriesid)
        {
            try
            {
                string sql = "SELECT * FROM movie WHERE seriesId = @seriesId";
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
                    int season = int.Parse(reader["season"].ToString());
                    int episode = int.Parse(reader["episode"].ToString());
                    int seriesId = int.Parse(reader["episode"].ToString());

                    Episode e = new Episode(id, name, year, url, genre, producer, desc, actors, duration, seriesId, season, episode);
                    episodes.Add(e);

                }
                reader.Close();
                conn.Close();
                return episodes;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        public static Episode GetEpisodeById(int id)
        {
            try
            {
                string sql = "Select * from movie WHERE id = @ID";
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
                    int season = int.Parse(reader["season"].ToString());
                    int episode = int.Parse(reader["episode"].ToString());
                    int seriesId = int.Parse(reader["episode"].ToString());

                    e = new Episode(Id, name, year, url, genre, producer, desc, actors, duration, seriesId, season, episode);
                    conn.Close();
                    return e;
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
    }
}

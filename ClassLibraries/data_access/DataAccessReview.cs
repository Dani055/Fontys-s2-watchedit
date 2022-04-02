using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.models;
using MySql.Data.MySqlClient;

namespace ClassLibraries.data_access
{
    public static class DataAccessReview
    {
        public static bool PostReviewQuery(int userId, int movieId, string description, int rating)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "INSERT INTO review (userId, movieId, description, rating) VALUES(@userId, @movieId, @description, @rating); ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@movieId", movieId);
                cmd.Parameters.AddWithValue("@description", description);
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
        public static Review GetUserReviewQuery(int userId, int movieId)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "Select * from review INNER JOIN user on user.id = review.userId WHERE userId = @userId AND movieId = @movieId ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@movieId", movieId);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    int Id = reader.GetInt32("id");
                    int Userid = reader.GetInt32("userId");
                    string Firstname = reader.GetString("firstName");
                    string Lastname = reader.GetString("lastName");
                    string ImageUrl = reader["imageUrl"].ToString();
                    int Movieid = reader.GetInt32("movieId");
                    string description = reader["description"].ToString();
                    int rating = reader.GetInt32("rating");

                    Review rev = new Review(Id, Userid, Firstname, Lastname, ImageUrl, Movieid, description, rating);
                    return rev;
                }
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public static Review GetReviewByIdQuery(int id)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "Select * from review INNER JOIN user on user.id = review.userId WHERE review.id = @id ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    int Id = reader.GetInt32("id");
                    int Userid = reader.GetInt32("userId");
                    string Firstname = reader.GetString("firstName");
                    string Lastname = reader.GetString("lastName");
                    string ImageUrl = reader["imageUrl"].ToString();
                    int Movieid = reader.GetInt32("movieId");
                    string description = reader["description"].ToString();
                    int rating = reader.GetInt32("rating");

                    Review rev = new Review(Id, Userid, Firstname, Lastname, ImageUrl, Movieid, description, rating);
                    return rev;
                }
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public static List<Review> GetReviewsQuery(int userId, int movieId, int offset)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "Select * from review INNER JOIN user on user.id = review.userId WHERE movieId = @movieId and userId != @userId LIMIT 4 OFFSET @offset";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@movieId", movieId);
                cmd.Parameters.AddWithValue("@offset", offset);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Review> reviews = new List<Review>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32("id");
                        int Userid = reader.GetInt32("userId");
                        string Firstname = reader.GetString("firstName");
                        string Lastname = reader.GetString("lastName");
                        string ImageUrl = reader["imageUrl"].ToString();
                        int Movieid = reader.GetInt32("movieId");
                        string description = reader["description"].ToString();
                        int rating = reader.GetInt32("rating");

                        Review rev = new Review(Id, Userid, Firstname, Lastname, ImageUrl, Movieid, description, rating);
                        reviews.Add(rev);
                    }

                }
                return reviews;
            }
            finally
            {
                conn.Close();
            }
        }
        public static List<Review> GetReviewsByMovieIdQuery(int movieId)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "Select * from review INNER JOIN user on user.id = review.userId WHERE movieId = @movieId";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@movieId", movieId);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Review> reviews = new List<Review>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32("id");
                        int Userid = reader.GetInt32("userId");
                        string Firstname = reader.GetString("firstName");
                        string Lastname = reader.GetString("lastName");
                        string ImageUrl = reader["imageUrl"].ToString();
                        int Movieid = reader.GetInt32("movieId");
                        string description = reader["description"].ToString();
                        int rating = reader.GetInt32("rating");

                        Review rev = new Review(Id, Userid, Firstname, Lastname, ImageUrl, Movieid, description, rating);
                        reviews.Add(rev);
                    }

                }
                return reviews;
            }
            finally
            {
                conn.Close();
            }
        }
        public static bool DeleteReviewQuery(int id)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "DELETE FROM review WHERE id = @ID";
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

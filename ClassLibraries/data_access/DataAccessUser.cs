using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.models;
using ClassLibraries.services;
using MySql.Data.MySqlClient;

namespace ClassLibraries.data_access
{
    public static class DataAccessUser
    {

        public static User LoginQuery (string username, string password)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "SELECT * FROM user WHERE username = @username and password = @password";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    int id = reader.GetInt32("id");
                    string uname = reader.GetString("username");
                    string pwd = reader.GetString("password");
                    string firstname = reader.GetString("firstName");
                    string lastname = reader.GetString("lastName");
                    string email = reader["email"].ToString();
                    string imageUrl = reader["imageUrl"].ToString();
                    bool isAdmin = Boolean.Parse(reader["isAdmin"].ToString());

                    User user = new User(id, isAdmin, uname, pwd, firstname, lastname, email, imageUrl);
                    reader.Close();
                    return user;
                }
                else
                {
                    reader.Close();
                    throw new Exception("Wrong username or password!");
                }
            }
            finally
            {
                conn.Close();
            }
        }
        public static bool RegisterQuery(string username, string password, string firstname, string lastname, string email, string imageurl)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "INSERT INTO user (username, password, firstName, lastName, email, imageUrl) VALUES(@username, @password, @firstname, @lastname, @email, @imageurl); ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@firstName", firstname);
                cmd.Parameters.AddWithValue("@lastName", lastname);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@imageUrl", imageurl);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return true;
            }
            finally
            {
                conn.Close();
            }
        }
        public static bool DeleteQuery(string username)
        {
            MySqlConnection conn = new MySqlConnection(Utils.conString);
            try
            {
                string sql = "DELETE FROM user WHERE username = @username ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);

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

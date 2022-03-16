using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraries.models;
using MySql.Data.MySqlClient;

namespace ClassLibraries.services
{
    public static class UserService
    {
        public static User loggedUser { get; set; } = null;
        private static MySqlConnection conn = new MySqlConnection(Utils.conString);

        public static bool Login(string username, string password)
        {
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
                    while (reader.Read())
                    {

                        int id = reader.GetInt32("id");
                        string uname = reader.GetString("username");
                        string pwd = reader.GetString("password");
                        string firstname = reader.GetString("firstName");
                        string lastname = reader.GetString("lastName");
                        string email = reader["email"].ToString();
                        string imageUrl = reader["imageUrl"].ToString();
                        bool isAdmin = Boolean.Parse(reader["isAdmin"].ToString());

                        User user = new User(id, isAdmin, uname, pwd, firstname, lastname, email, imageUrl);
                        UserService.loggedUser = user;
                    }
                    reader.Close();
                    return true;
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

        public static bool Register(string username, string password, string firstname, string lastname, string email, string imageurl)
        {
            try
            {
                if (username.Length < 3)
                {
                    throw new Exception("Username must be at least 3 characters long!");
                }
                else if (password.Length < 3)
                {
                    throw new Exception("Password must be at least 3 characters long!");
                }
                else if (String.IsNullOrEmpty(firstname))
                {
                    throw new Exception("You must enter a first name!");
                }
                else if (String.IsNullOrEmpty(lastname))
                {
                    throw new Exception("You must enter a last name!");
                }
                else if (email.Length <= 5)
                {
                    throw new Exception("Email must be valid!");
                }

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

        public static bool DeleteUser(string username)
        {
            try
            {
                if (username.Length < 3)
                {
                    throw new Exception("Username must be at least 3 characters long!");
                }
                
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

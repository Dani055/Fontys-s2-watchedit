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
                        
                        User user = new User(id, isAdmin,uname, pwd, firstname, lastname, email, imageUrl);
                        UserService.loggedUser = user;
                    }
                    reader.Close();
                    conn.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Wrong username or password!");
                }
                reader.Close();
                conn.Close();
                return false;

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static bool Register(string username, string password, string firstname, string lastname, string email, string imageurl)
        {
            if (username.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters long!");
                return false;
            }
            else if (password.Length < 3)
            {
                MessageBox.Show("Password must be at least 3 characters long!");
                return false;
            }
            else if (firstname.Length <= 0)
            {
                MessageBox.Show("You must enter a first name!");
                return false;
            }
            else if (lastname.Length <= 0)
            {
                MessageBox.Show("You must enter a first name!");
                return false;
            }
            else if (email.Length <= 5)
            {
                MessageBox.Show("Email must be valid!");
                return false;
            }
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
                MessageBox.Show("User registered successfully");
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
    }                               
}                                   
